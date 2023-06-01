using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace WebAppChurrasco.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebAppChurrascoUser class
public class WebAppChurrascoUser : IdentityUser
{
    [MaxLength(256, ErrorMessage = "O tamanho máximo do campo são 256 caracteres")]
    [Required]
    public string Nome { get; set; }

    [MaxLength(15, ErrorMessage = "O tamanho máximo do campo são 15 caracteres")]
    public string Telefone { get; set; }
}

