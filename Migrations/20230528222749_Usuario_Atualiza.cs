using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Usuario_Atualiza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescChurras",
                table: "Churrasco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataChurras",
                table: "Churrasco",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    IdParticipantes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChurras = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VlContribuicao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VlSugeridoComBebida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.AlterColumn<string>(
                name: "DescChurras",
                table: "Churrasco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataChurras",
                table: "Churrasco",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
