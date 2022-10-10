using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLOUD_LIB;

namespace CLOUD_DATA
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UtilizadorModel> Utilizador { get; set; }
        public DbSet<ArtigoModel> Artigo { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<FaturaModel> Fatura { get; set; }
        public DbSet<DetalhesFatura> DetalhesFatura { get; set; }
    }
}
