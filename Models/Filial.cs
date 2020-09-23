﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Models
{
    [Table("Filial")]
    public class Filial
    {
        

        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        /*EF Relation*/

        public IEnumerable<Impressora> Impressoras { get; set; }
    }
}