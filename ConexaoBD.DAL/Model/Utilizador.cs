using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConexaoBD.DAL.Model
{
    public class Utilizador : Entidade
    {
        [EmailAddress(ErrorMessage = "Deve inserir um endereço de e-mail válido")]
        [Display(Name = "E-Mail")]
        public string EmailLogin { get; set; }

        //
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [MinLength(6, ErrorMessage = "Este campo não pode possuir menos de 6 caracteres")]
        public string PasswordLogin { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Senha de Confirmação")]
        [Compare("PasswordLogin", ErrorMessage = "Password de confirmação diferente")]
        public string PasswordConfirmacao { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        [MinLength(6, ErrorMessage = "Este campo não pode possuir menos de 6 caracteres")]
        public string PasswordAntiga { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Nova")]
        [MinLength(6, ErrorMessage = "Este campo não pode possuir menos de 6 caracteres")]
        public string PasswordNova { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Senha de Confirmação")]
        public string PasswordNovaConfirmacao { get; set; }

        [Required]
        [Display(Name = "Id do Grupo de Utilizadores")]
        public int GrupoDeUtilizadoresId { get; set; }

        [ForeignKey("GrupoDeUtilizadoresId")]
        [Display(Name = "Grupo de Utilizadores")]
        public virtual GrupoDeUtilizadores GrupoDeUtilizadores { get; set; }



        //[DataType(DataType.Upload)]
        //public byte[] Avatar { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("                ID: " + Id);
            sb.AppendLine("              Nome: " + Nome);
            sb.AppendLine("   E-mail de Login: " + EmailLogin);
            sb.AppendLine("    Senha de Login: " + PasswordLogin);
            sb.AppendLine("             Ativo: " + Ativo);
            sb.AppendLine("   Data de Criação: " + DataCriacao);
            sb.AppendLine(" Data de Alteração: " + DataAlteracao);
            return sb.ToString();
        }
    }
}
