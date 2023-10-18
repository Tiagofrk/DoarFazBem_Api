using DoarFazBem_Api.Enum;

namespace DoarFazBem.Models;

public class Doador
{
    public int id_doador { get; set; }
    public TipoSanguineo tipo_sanguineo { get; set; }
    public int cep { get; set; }
    public decimal peso { get; set; }
    public decimal altura { get; set; }

}