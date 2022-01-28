using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.MVC.Models
{
    public class ValidacaoDePasswordAttribute : ValidationAttribute
    {
        public ValidacaoDePasswordAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var utilizador = (Utilizador)validationContext.ObjectInstance;

            ConexaoBDContexto ctx = new ConexaoBDContexto();
            string passwordLogin = ctx.Utilizadores.FirstOrDefault(u => u.Id == utilizador.Id).PasswordLogin;

            CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();
            string passwordInserida = codificacaoDePassword.ObterHashMD5((string)value);

            if (passwordLogin != passwordInserida)
            {
                //return new ValidationResult(GetErrorMessage());
                return new ValidationResult($"A password antiga está errada");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}
