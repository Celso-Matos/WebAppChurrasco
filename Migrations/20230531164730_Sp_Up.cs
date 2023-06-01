using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class Sp_Up : Migration
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
                        coalesce(P.IdParticipantes, 0) IdParticipantes
                        ,coalesce(U.Nome, '') Nome
                        ,coalesce(U.Telefone, '') Telefone
                        ,coalesce(U.Email, '') Email						
                        ,coalesce(P.VlContribuicao, 0) VlContribuicao
                        ,coalesce(P.VlSugeridoComBebida, 0) VlSugeridoComBebida
                        ,coalesce(P.VlSugeridoSemBebida, 0) VlSugeridoSemBebida
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
