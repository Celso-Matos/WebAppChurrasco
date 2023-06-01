using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Sp_New_Up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE sp_AgendaChurras 
	                    (
	                    @IdChurras int
	                    )
                    AS
                    BEGIN
						
						BEGIN TRY

	                    SET NOCOUNT ON;

                        SELECT DISTINCT
                        coalesce(U.Nome, '') Nome
                        ,coalesce(U.Telefone, '') Telefone
                        ,coalesce(U.Email, '') Email						
                        ,coalesce(P.VlContribuicao, 0) VlContribuicao
                        ,coalesce(P.VlSugeridoComBebida, 0) VlSugeridoComBebida
                        ,coalesce(P.VlSugeridoSemBebida, 0) VlSugeridoSemBebida
                        ,coalesce(P.DataCriacaoParticipantes, 0) DataCriacaoParticipantes						
                        FROM [dbo].[Churrasco] C
                        LEFT JOIN [dbo].[Participantes] P ON C.IdChurras = P.IdChurras
                        LEFT JOIN [dbo].[AspNetUsers] U ON P.Id = U.Id
	                    WHERE C.IdChurras = @IdChurras
						
						END TRY
						BEGIN CATCH
							RAISERROR ('Erro na consulta contate o Administrador do Sistema.',16,1)
						END CATCH

                    END";

            migrationBuilder.Sql(sp);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
