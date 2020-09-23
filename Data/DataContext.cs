using Microsoft.EntityFrameworkCore;
using PrintManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base (options)
        {

        }

        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<LogsImpressao> LogsImpressaos { get; set; }

        public DbSet<Impressora> Impressoras { get; set; }

        public DbSet<Fornecedor> Fornecedors{ get; set; }

        public DbSet<Filial> Filials{ get; set; }

        public DbSet<Departamento> Derpartamentos{ get; set; }

        public DbSet<ContratoDeImpressora> ContratoDeImpressoras{ get; set; }

        public DbSet<ContadorDeImpressao> contadorDeImpressaos{ get; set; }


    }
}
