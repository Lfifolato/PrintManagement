using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Endereço:")]       
        public string Endereco { get; set; }


        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Contato/Suporte:")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Site:")]
        public string Site { get; set; }

        /*EF Relation*/

        public ContratoDeImpressora ContratoDeImpressora{ get; set; }

    }
}
