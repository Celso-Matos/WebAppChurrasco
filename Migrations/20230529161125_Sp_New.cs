using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Sp_New : Migration
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

	                    SELECT 
	                    coalesce(C.IdChurras,0) IdChurras
						,coalesce(C.DescChurras,'') DescChurras
						,coalesce(C.ObsAdsChurras,'') ObsAdsChurras
						,coalesce(C.DataChurras, '') DataChurras
						,coalesce(C.DataCriacaoChurras, '') DataCriacaoChurras
						,coalesce(P.IdParticipantes, 0) IdParticipantes
						,coalesce(P.Id, 0) Id
						,coalesce(P.VlContribuicao, 0) VlContribuicao
						,coalesce(P.VlSugeridoComBebida, 0) VlSugeridoComBebida
						,coalesce(P.VlSugeridoSemBebida, 0) VlSugeridoSemBebida
						,coalesce(P.DataCriacaoParticipantes, '') DataCriacaoParticipantes
						,coalesce(U.Nome, '') Nome
						,coalesce(U.UserName, '') UserName
						,coalesce(U.Telefone, '') Telefone
						,coalesce(U.Email, '') Email
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
