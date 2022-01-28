using System;
using System.ComponentModel.DataAnnotations;

namespace ConexaoBD.DAL.Model
{
    public class UtilizadorPasswordDto
    {
        public Guid Id { get; set; }

        public string PasswordLogin { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string PasswordAntiga { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string PasswordNova { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [Compare("PasswordNova", ErrorMessage = "Password de confirmação diferente")]
        public string PasswordNovaConfirmacao { get; set; }
    }
}
