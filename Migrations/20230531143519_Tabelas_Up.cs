using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Tabelas_Up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUserCriacao",
                table: "Participantes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserCriacao",
                table: "Churrasco",
                type: "nvarchar(450)",
                nullable: true);
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
