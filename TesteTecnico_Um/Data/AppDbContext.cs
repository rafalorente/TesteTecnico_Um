using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico_Um.Models;

namespace TesteTecnico_Um.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        {

        }

        public DbSet<Caminhao> Caminhao { get; set; }

        public DbSet<Motorista> Motorista { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
    }
}
