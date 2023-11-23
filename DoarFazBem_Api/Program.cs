using DoarFazBem_Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

if (mySqlConnection != null)
{
    builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

}
else
{
    throw new InvalidOperationException("A string de conexão é nula. Verifique a configuração.");
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoarFazBem-Api", Version = "v1" });
    c.ResolveConflictingActions(x => x.First()); // Esta linha resolve o conflito de ações que estão usando a mesma rota e gerando ambiguidade.
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
            builder => builder.WithOrigins("http://127.0.0.1:5500/", "https://dofazbem.org/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoarFazBem-Api");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowMyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
