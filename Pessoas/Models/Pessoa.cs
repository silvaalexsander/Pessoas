using System.ComponentModel.DataAnnotations;

namespace Pessoas.Models
{
    public class Pessoa
    {
        [Key]
        public int idPessoa { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        [StringLength(50, ErrorMessage ="O nome deve ter no maximo 50 caracteres")]
        [Display(Name = "Nome: ")]
        public String  name { get; set; }

        [Required(ErrorMessage ="O endereço é obrigatório")]
        [StringLength(80, ErrorMessage ="O endereço deve conter no maximo 80 caracteres")]
        [Display(Name = "Endereço: ")]
        public String address { get; set; }
    }
}
