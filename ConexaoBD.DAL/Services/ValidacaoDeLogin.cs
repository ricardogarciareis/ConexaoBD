﻿using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model
{
    public class ValidacaoDeLoginAttribute : ValidationAttribute
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
            var utilizador = (UtilizadorLoginDto)validationContext.ObjectInstance;

            ConexaoBDContexto ctx = new ConexaoBDContexto(); //Melhorar| Ver acima

            string passwordLogin = ctx.Utilizadores.FirstOrDefault(u => u.EmailLogin == utilizador.EmailLogin).PasswordLogin;

            CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();
            string passwordInserida = codificacaoDePassword.ObterHashMD5((string)value);

            if (passwordLogin != passwordInserida)
            {
                //return new ValidationResult(GetErrorMessage());
                return new ValidationResult($"Utilizador não existe ou senha errada");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}