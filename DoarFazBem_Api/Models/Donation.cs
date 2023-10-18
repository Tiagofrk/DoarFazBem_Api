using DoarFazBem_Api.Enum;

namespace DoarFazBem.Models
{
    public class Donation
    {
        public int id_donation { get; set; }
        public int id_doador { get; set; }
        public int id_hemocentro { get; set; }
        public DateTime data_coleta { get; set; }
        public TipoSanguineo tipo_sanguineo { get; set; }
        public decimal batimentos { get; set; }
        public decimal temperatura { get; set; }
    }
}
