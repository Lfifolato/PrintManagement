using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{   
    [Table("Tecnico")]
    public class Tecnico
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "E-mail:")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Filial:")]
        [ForeignKey("Filial")]
        public long IdFilial { get; set; }

        /*EF Relation*/

        public Filial Filial { get; set; }

        public IEnumerable<ContadorDeImpressao> ContadorDeImpressaos{ get; set; }

    }
}
