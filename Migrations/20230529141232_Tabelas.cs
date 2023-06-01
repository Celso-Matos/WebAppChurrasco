using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Churrasco",
                columns: table => new
                {
                    IdChurras = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescChurras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObsAdsChurras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataChurras = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacaoChurras = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churrasco", x => x.IdChurras);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
