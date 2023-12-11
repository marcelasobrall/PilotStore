using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PilotStore_.Models;
using System.IO;

namespace PilotStore_.Data
{
    public class PilotStoreDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string conn = config.GetConnectionString("Conn");

            optionsBuilder.UseSqlServer(conn);
        }
    }
}
