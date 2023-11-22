using System.ComponentModel.DataAnnotations;

namespace DoarFazBem.Models
{
    public class Login
    {
        [Key]
        public decimal cpf { get; set; }
        public string? password_dfb { get; set; }
    }
}
