namespace DoarFazBem.Models;

public class Usuario
{
    public int Id { get; set; }
    public string? CPF { get; set; }
    public string? Nome { get; set; }
    public string? Sexo { get; set; }
    public DateTime Nascimento { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public string? Nascionalidade { get; set; }
}