using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("Impressora")]
    public class Impressora
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Display(Name = "Serial:")]
        public string Serial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Filial:")]
        [ForeignKey("Filial")]
        public long IdFilial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Modelo:")]
        [ForeignKey("Modelo")]
        public long IdModelo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Derpartamento:")]
        [ForeignKey("Departamento")]
        public long IdDepartamento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Contrato Da Impressora:")]
        [ForeignKey("ContratoDeImpressora")]
        public long IdContrato { get; set; }

        /*EF Relation*/

        public Modelo Modelo { get; set; }

        public Filial Filial { get; set; }

        public Departamento Departamento{ get; set; }

        public ContratoDeImpressora ContratoDeImpressora { get; set; }

        public IEnumerable<ContadorDeImpressao> ContadorDeImpressaos { get; set; }

    }
}
