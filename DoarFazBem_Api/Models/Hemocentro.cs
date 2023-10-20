using System.ComponentModel.DataAnnotations;

namespace DoarFazBem.Models;


public class Hemocentro
{
    [Key]
    public int id_hemocentro { get; set; }
    public string? nome { get; set; }
    public string? endereco { get; set; }
    public string? cep { get; set; }
}
