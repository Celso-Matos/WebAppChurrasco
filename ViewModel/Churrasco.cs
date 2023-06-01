using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using WebAppChurrasco.Areas.Identity.Data;
using WebAppChurrasco.Entities;

namespace WebAppChurrasco.ViewModel
{
    public class Churrasco
    {
        [Key]
        public int IdChurras { get; set; }

        [Display(Name = "Descrição do Churras")]
        [Required(ErrorMessage = " - A Descrição do Churras é obrigatória")]
        public string? DescChurras { get; set; }

        [Display(Name = "Observações Adicionais")]
        public string? ObsAdsChurras { get; set; }

        [Display(Name = "Data do Churras")]
        [Required(ErrorMessage = " - A Data do Churras é obrigatória")]
        public DateTime? DataChurras { get; set; }
        public DateTime DataCriacaoChurras { get; set; }
        public IEnumerable<Entities.Churrasco>? ListaChurras { get; set; }
        public List<string> ListaUsuarios { get; set; } = new List<string>();
        public IList<Entities.Participantes>? ListParticipantesChurras { get; set; }
        public IEnumerable<WebAppChurrascoUser>? GetUsers { get; set; }
        public IEnumerable<AgendaChurras>? ListaAgendaChurras { get; set; }
        public string? Id { get; set; }

        [Display(Name = "Valor da Contribuição")]
        [Required(ErrorMessage = " - O Valor da Contribuição é obrigatorio")]
        public decimal VlContribuicao { get; set; }

        [Display(Name = "Valor Sugerido com a Bebida")]
        [Required(ErrorMessage = " - O Valor da Sugerido com a Bebida é obrigatorio")]
        public decimal VlSugeridoComBebida { get; set; }

        [Display(Name = "Valor Sugerido sem a Bebida")]
        [Required(ErrorMessage = " - O Valor da Sugerido sem a Bebida é obrigatorio")]
        public decimal VlSugeridoSemBebida { get; set; }

        [Display(Name = "Data de Adição")]
        public DateTime DataCriacaoParticipantes { get; set; }

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "Login")]
        public string? UserName { get; set; }

        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
        public string? UserCriacao { get; set; }

        [Display(Name = "Total de Participantes")]
        public int TotalParticipantes { get; set; }

        [Display(Name = "Valor Arrecadado")]
        public decimal? ValorArrecadado { get; set; }


    }
}
