using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models.ProfileViewModels
{
    public class ProfileViewModel
    {

        [Required]
        [Display(Name = "Tipo de Perfil")]
        public int ProfileTypeID { get; set; }

        public IFormFile AvatarImage { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Pelo menos mais de 6 Caracteres.", MinimumLength = 6)]
        [Display(Name = "Nome Completo?")]
        public string Name{ get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Introduza o numero de telefone.")]
        public string PhoneNumber { get; set; }


    }
}
