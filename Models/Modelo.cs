using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("Modelo")]
    public class Modelo
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Display(Name = "Marca:")]
        public string Marca { get; set; }

        /*EF Relation*/

        public IEnumerable<Impressora> Impressoras { get; set; }
    }
}
