using System.ComponentModel.DataAnnotations;

namespace DoarFazBem.Models
{
    public class Login
    {
        [Key]
        public int cpf { get; set; }
        public string? password { get; set; }
    }
}
