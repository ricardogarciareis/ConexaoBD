using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConexaoBD.WEB.MVC.Controllers
{
    public partial class UtilizadorController : Controller
    {
        private Utilizador ValidarLoginSenha(string login, string palavraPasse)
        {
            // Transformação da palavraPasse do utilizador em Hash MD5
            CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();

            var hashCalculado = codificacaoDePassword.ObterHashMD5(palavraPasse);
            // Captura do objeto utilizador
            var utilizador = ctx.Utilizadores.FirstOrDefault(x => x.EmailLogin == login && x.PasswordLogin == hashCalculado);

            // Criação do Cookie e Prazo de validade do Cookie
            var cookieOptions = new CookieOptions
            { 
                Expires = new DateTimeOffset(DateTime.Now.AddMinutes(30))
            };
            //Inserção de dados no cookie
            if (utilizador != null)
            {
                HttpContext.Response.Cookies.Append("NomeDoUtilizador", utilizador.Nome, cookieOptions);
            }
            else
            {
                HttpContext.Response.Cookies.Append("NomeDoUtilizador", "", cookieOptions);
                ViewBag.PasswordErrada = "Utilizador não existe ou Password errada";
            }

            // Retorno do objeto utilizador
            return utilizador;
        }


        public ActionResult EfetuarLogin()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];
            var utilizador = new Utilizador
            {
                //Pré-Definições:

            };
            return View(utilizador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EfetuarLogin(UtilizadorLoginDto utilizador)
        {
            //var resultado = ValidarLoginSenha(emailLogin, passwordLogin);
            if (ModelState.IsValid)
            {
                if(ValidarLoginSenha(utilizador.EmailLogin, utilizador.PasswordLogin) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                //ValidarLoginSenha(utilizador.EmailLogin, utilizador.PasswordLogin);

                //return View(resultado);
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public ActionResult EfetuarLogout()
        {
            // Criação do Cookie e Prazo de validade do Cookie
            var cookieOptions = new CookieOptions
            {
                Expires = new DateTimeOffset(DateTime.Now.AddMinutes(30))
            };
            HttpContext.Response.Cookies.Append("NomeDoUtilizador", "", cookieOptions);
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Home");
        }


    }
}
