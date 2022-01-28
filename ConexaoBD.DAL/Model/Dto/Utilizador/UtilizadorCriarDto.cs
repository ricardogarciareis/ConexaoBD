using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexaoBD.DAL.Model
{
    public class UtilizadorCriarDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string EmailLogin { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string PasswordLogin { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [Compare("PasswordLogin", ErrorMessage = "Password de confirmação diferente")]
        public string PasswordConfirmacao { get; set; }


        public int GrupoDeUtilizadoresId { get; set; }

        [ForeignKey("GrupoDeUtilizadoresId")]
        public virtual GrupoDeUtilizadores GrupoDeUtilizadores { get; set; }

    }
}
