using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppChurrasco.Migrations
{
    /// <inheritdoc />
    public partial class sp_AgendaChurras : Migration
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

	                    SET NOCOUNT ON;

	                    SELECT 
	                    C.IdChurras
						,C.DescChurras
						,C.ObsAdsChurras
						,C.DataChurras
						,C.DataCriacaoChurras
						,P.IdParticipantes
						,P.Id
						,P.VlContribuicao
						,P.VlSugeridoComBebida
						,P.VlSugeridoSemBebida
						,P.DataCriacaoParticipantes
						,U.Nome
						,U.UserName
						,U.Telefone
						,U.Email
	                    FROM [dbo].[Churrasco] C
	                    LEFT JOIN [dbo].[Participantes] P ON C.IdChurras = P.IdChurras
	                    LEFT JOIN [dbo].[AspNetUsers] U ON P.Id = U.Id
	                    WHERE C.IdChurras = @IdChurras

                    END";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
