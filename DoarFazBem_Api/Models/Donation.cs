using DoarFazBem_Api.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoarFazBem.Models
{
    public class Donation
    {
        [Key]
        public int id_donation { get; set; }
        [ForeignKey("Doador")]
        public int id_doador { get; set; }
        public virtual Doador? Doador { get; set; }
        [ForeignKey("Hemocentro")]
        public int id_hemocentro { get; set; }
        public virtual Hemocentro? Hemocentro { get; set; }
        public DateTime data_coleta { get; set; }
        public TipoSanguineo tipo_sanguineo { get; set; }
        public decimal batimentos { get; set; }
        public decimal temperatura { get; set; }
    }
}
