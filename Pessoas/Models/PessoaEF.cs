using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pessoas.Models
{
    
    public class PessoaEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPessoa { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="O nome deve ter no maximo 60 caracteres")]
        [Display(Name = "Nome")]
        public String Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="O endereço deve ter no maximo 50 caracteres")]
        [Display(Name = "Endereço")]
        public String Address { get; set; }
    }
}
