using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2Su.Models
{
    public class Context : DbContext
    {
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Tipomovi> Tipomovis { get; set; }
        public DbSet<Escolha> Escolhas { get; set; }
        public DbSet<Cate> Cates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=T2Suu;Trusted_Connection = true");
        }


    }
}
