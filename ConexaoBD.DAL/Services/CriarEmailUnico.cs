using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model
{
    public class CriarEmailUnicoAttribute : ValidationAttribute
    {
        //readonly ConexaoBDContexto ctx;

        //public validacaoDePasswordAttribute()
        //{
        //    ctx = new ConexaoBDContexto();
        //}

        //public ValidacaoDePasswordAttribute(ConexaoBDContexto _ctx) //Isto obriga a utilizar um parâmetro da Annotation
        //{
        //    ctx = _ctx;

        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var utilizador = (UtilizadorCriarDto)validationContext.ObjectInstance;

            ConexaoBDContexto ctx = new ConexaoBDContexto(); //Melhorar| Ver acima

            var utilizadorEncontrado = ctx.Utilizadores.FirstOrDefault(u => u.EmailLogin == utilizador.EmailLogin);

            if (utilizadorEncontrado != null)
            {
                //return new ValidationResult(GetErrorMessage());
                return new ValidationResult($"Este email de utilizador já existe");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}
