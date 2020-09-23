using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("ContratoDeImpressora")]
    public class ContratoDeImpressora
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Tipo:")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Fornecedor:")]
        [ForeignKey("Fornecedor")]
        public long IdFornecedor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Franquia:")]
        public int Franquia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Valor do Contrato:")]
        public decimal ValorContratado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Valor de Execetente:")]
        public decimal ValorExcedente { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Vigencia:")]
        public int Vigencia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Data Inicio:")]
        public DateTime DataInicio { get; set; }


        /*EF Relation*/

        public Fornecedor Fornecedor { get; set; }

        public IEnumerable<Impressora> Impressoras { get; set; }

    }
}
