using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppChurrasco.ViewModel
{
    public class Participantes
    {
        [Key]
        public int IdParticipantes { get; set; }

        public int IdChurras { get; set; }

        public string? Id { get; set; }

        public decimal VlContribuicao { get; set; }

        public decimal VlSugeridoComBebida { get; set; }

        public decimal VlSugeridoSemBebida { get; set; }

        public DateTime DataCriacaoParticipantes { get; set; }

        public string? UserCriacao { get; set; }
    }
}
