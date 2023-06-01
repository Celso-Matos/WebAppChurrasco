using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas_New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    IdParticipantes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChurras = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VlContribuicao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VlSugeridoComBebida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VlSugeridoSemBebida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacaoParticipantes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.IdParticipantes);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
