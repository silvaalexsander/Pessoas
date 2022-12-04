using Microsoft.EntityFrameworkCore;
using Pessoas.Models;

namespace Pessoas.Repository.Context
{
    public class DataBaseContext : DbContext
    {
 
        public DbSet<PessoaEF> PessoaEF { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("TableConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}