using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.MVC.Models
{
    //Vídeo 66 - 01:00
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password de Confirmação")]
        [Compare("Password", ErrorMessage = "As duas passwords não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
