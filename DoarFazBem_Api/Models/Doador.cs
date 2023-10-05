namespace DoarFazBem.Models;

public class Doador
{
    public int id_doador { get; set; }
    public string? TipoSanguineo { get; set; }
    public string? NomeCidade { get; set; }
    public string? NomeEstado { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }

}