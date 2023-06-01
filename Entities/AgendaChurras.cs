using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppChurrasco.Entities
{
    public class AgendaChurras
    {
        [Key]
        public int IdParticipantes { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public decimal? VlContribuicao { get; set; }
        public decimal? VlSugeridoComBebida { get; set; }
        public decimal? VlSugeridoSemBebida { get; set; }
        public DateTime? DataCriacaoParticipantes { get; set; }        

    }
}
