using DoarFazBem_Api.Enum;

namespace DoarFazBem.Models;

public class Usuario
{
    public int cpf { get; set; }
    public string? nome { get; set; }
    public string? email { get; set; }
    public TipoSanguineo tipo_sanguineo { get; set; }
    public string? cep { get; set; }
}