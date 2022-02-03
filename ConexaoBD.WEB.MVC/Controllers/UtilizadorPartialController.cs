using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

        [HttpGet("Utilizador/EfetuarLogin")]
        public ActionResult EfetuarLogin(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];
            var utilizador = new Utilizador
            {
                //Pré-Definições:

            };
            return View(utilizador);

            //https://www.youtube.com/watch?v=BWa7Mu-oMHk&list=PLH-n_HU-47l5hp4VPKpUi-VQQlcnRg15h&index=11&t=185s
            //ASP.NET Core 5.0 - Authentication/Authorization - .Net Engineering Forum 2021-01-26 -> 14:08
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EfetuarLogin(UtilizadorLoginDto utilizador, string returnUrl)
        {
            //var resultado = ValidarLoginSenha(emailLogin, passwordLogin);
            if (ModelState.IsValid)
            {
                if (ValidarLoginSenha(utilizador.EmailLogin, utilizador.PasswordLogin) != null)
                {
                    //var claims = new List<Claim>();
                    //claims.Add(new Claim("emailLogin", utilizador.EmailLogin));
                    //claims.Add(new Claim(ClaimTypes.NameIdentifier, utilizador.EmailLogin));
                    //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    //await HttpContext.SignInAsync(claimsPrincipal);
                    //return Redirect(returnUrl);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            //https://www.youtube.com/watch?v=BWa7Mu-oMHk&list=PLH-n_HU-47l5hp4VPKpUi-VQQlcnRg15h&index=11&t=185s
            //ASP.NET Core 5.0 - Authentication/Authorization - .Net Engineering Forum 2021-01-26 -> 14:08
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EfetuarLogin(UtilizadorLoginDto utilizador, string returnUrl)
        //{
        //    //var resultado = ValidarLoginSenha(emailLogin, passwordLogin);
        //    if (ModelState.IsValid)
        //    {
        //        if(ValidarLoginSenha(utilizador.EmailLogin, utilizador.PasswordLogin) != null)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

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
