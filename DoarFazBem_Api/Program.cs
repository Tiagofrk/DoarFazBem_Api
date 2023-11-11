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
    throw new InvalidOperationException("A string de conex�o � nula. Verifique a configura��o.");
}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.ResolveConflictingActions(x => x.First()); // Esta linha resolve o conflito de a��es que est�o usando a mesma rota e gerando ambiguidade.
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
            builder => builder.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowMyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
