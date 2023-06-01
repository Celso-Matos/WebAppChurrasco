using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppChurrasco.Entities
{
    public class Churrasco
    {
        [Key]
        public int IdChurras { get; set; }
        public string? DescChurras { get; set; }
        public string? ObsAdsChurras { get; set; }
        public DateTime? DataChurras { get; set; }
        public DateTime DataCriacaoChurras { get; set; }
        public string? IdUserCriacao { get; set; }


    }
}
