using DoarFazBem_Api.Enum;
using System.ComponentModel.DataAnnotations;

namespace DoarFazBem.Models;

public class Usuario
{
    [Key]
    public decimal cpf { get; set; }
    public string? nome { get; set; }
    public string? email { get; set; }
    public TipoSanguineo tipo_sanguineo { get; set; }
    public string? senha { get; set; }
    public byte[]? senhaHash { get; set; } 
    public byte[]? senhaSalt { get; set; }
}