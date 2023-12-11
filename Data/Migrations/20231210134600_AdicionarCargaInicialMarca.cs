using Microsoft.EntityFrameworkCore.Migrations;
using PilotStore_.Data;
using PilotStore_.Models;


#nullable disable

namespace PilotStore_.data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCargaInicialMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new PilotStoreDbContext();
            context.Marca.AddRange(ObterCaragaInicial());
            context.SaveChanges();

        }

        private IList<Marca> ObterCaragaInicial()
        {
            return new List<Marca>()
            {
                new Marca() { Descricao = "Flight Outfitters"},
                new Marca() { Descricao = "ASA"},
                new Marca() { Descricao = "AOPA Pilot Gear"},
            };
        }
    }
}