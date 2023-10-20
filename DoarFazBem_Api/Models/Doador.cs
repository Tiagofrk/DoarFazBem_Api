using DoarFazBem_Api.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoarFazBem.Models;

public class Doador
{
    [Key]
    public int id_doador { get; set; }
    public TipoSanguineo tipo_sanguineo { get; set; }
    public string? cep { get; set; }
    public decimal peso { get; set; }
    public decimal altura { get; set; }

}