namespace DoarFazBem.Models;

public class Usuario
{
    public int id { get; set; }
    public string? cpf { get; set; }
    public string? nome { get; set; }
    public string? sexo { get; set; }
    public DateTime nascimento { get; set; }
    public decimal peso { get; set; }
    public decimal altura { get; set; }
    public string? nascionalidade { get; set; }
}