namespace DoarFazBem.Models;

public class Doador
{
    public int Id { get; set; }
    public string? tipo_sanguineo { get; set; }
    public string? nome_cidade { get; set; }
    public string? nome_estado { get; set; }
    public decimal peso { get; set; }
    public decimal altura { get; set; }

}