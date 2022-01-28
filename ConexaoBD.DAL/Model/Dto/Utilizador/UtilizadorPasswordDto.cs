using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model
{
    public class UtilizadorPasswordDto
    {
        public Guid Id { get; set; }

        public string PasswordLogin { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [ValidacaoDePassword]
        public string PasswordAntiga { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string PasswordNova { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [Compare("PasswordNova", ErrorMessage = "Password de confirmação diferente")]
        public string PasswordNovaConfirmacao { get; set; }
    }
}
