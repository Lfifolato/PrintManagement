using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("LogsImpressao")]
    public class LogsImpressao
    {   
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Column("teste te")]
        public string Nome { get; set; }
    }
}
