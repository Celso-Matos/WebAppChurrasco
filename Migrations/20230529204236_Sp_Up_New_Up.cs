using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Sp_Up_New_Up : Migration
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
                        U.Nome Nome
                        ,U.Telefone Telefone
                        ,U.Email Email						
                        ,P.VlContribuicao VlContribuicao
                        ,P.VlSugeridoComBebida VlSugeridoComBebida
                        ,P.VlSugeridoSemBebida VlSugeridoSemBebida
                        ,P.DataCriacaoParticipantes DataCriacaoParticipantes						
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
