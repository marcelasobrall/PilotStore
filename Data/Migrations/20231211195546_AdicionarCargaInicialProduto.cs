using Microsoft.EntityFrameworkCore.Migrations;
using PilotStore_.Models;

#nullable disable

namespace PilotStore_.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new PilotStoreDbContext();
            context.Products.AddRange(ObterCaragaInicial());
            context.SaveChanges();
        }

        private IList<ProductModel> ObterCaragaInicial()  // Corrigir o nome do método
        {
            return new List<ProductModel>
            {
                new ProductModel
                {
                    Name = "Camisa",
                    Description = "Camisa Pilotos",
                    Price = 279.90,
                    ReleaseDate = DateTime.Parse("2023-01-15"),
                    ImagePath = "/images/product1-camisa.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Name = "Computador de Voo",
                    Description = "Para prova da ANAC",
                    Price = 150.90,
                    ReleaseDate = DateTime.Parse("2023-02-20"),
                    ImagePath = "/images/product2-computador-voo.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Name = "Chaveiro",
                    Description = "Chaveiro retire antes de voar",
                    Price = 40.00,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product3-chaveiro.png",
                    IsActive = false
                },
                new ProductModel
                {
                    Name = "Quepe",
                    Description = "Quepe para pilotos",
                    Price = 220.90,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product4-quepe.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Name = "Par Berimbelas",
                    Description = "Berimbelas pretas básicas",
                    Price = 39.90,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product5-par-berimbelas.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Name = "Brevê Aviação",
                    Description = "Brasão da República",
                    Price = 39.99,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product6-breve-aviacao.png",
                    IsActive = false
                },
            };
        }
    }
}