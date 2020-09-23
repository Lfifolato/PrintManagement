using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("ContadorDeImpressao")]
    public class ContadorDeImpressao
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Quantidade:")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Empressora:")]
        [ForeignKey("Impressora")]
        public long IdImpressora { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Data Da Leitura:")]
        public DateTime DataLeitura { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome Do Usuario:")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Departamento:")]
        [ForeignKey("Departamento")]
        public long IdDepartamento { get; set; }

        /*EF Relation*/

        public Impressora Impressora { get; set; }

        public Departamento Departamento{ get; set; }
    }
}
