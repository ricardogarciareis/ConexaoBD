using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoBD.WEB.MVC.Controllers
{
    public partial class UtilizadorController : Controller
    {
        //CRUD de acesso à Base de Dados:
        readonly ConexaoBDContexto ctx;

        public UtilizadorController(ConexaoBDContexto _ctx)
        {
            ctx = _ctx;
        }

        // GET: UtilizadorController
        public ActionResult Index()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var utilizadores = ctx.Utilizadores.Include("GrupoDeUtilizadores").OrderBy(u => u.Nome);
 
            return View(utilizadores);
        }

        // GET: UtilizadorController/Details/5
        public ActionResult Details(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var utilizador = ctx.Utilizadores.Include("GrupoDeUtilizadores").FirstOrDefault(u => u.Id == id);
            return View(utilizador);
        }

        // GET: UtilizadorController/Create
        public ActionResult Create()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            IEnumerable<string> lista = ctx.GrupoDeUtilizadores.Select(g => g.Nome).ToList();
            ViewBag.ListaNomesGruposDeUtilizadores = lista;

            var utilizador = new Utilizador
            {
                //Pré-Definições:

            };
            return View(utilizador);
        }

        // POST: UtilizadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UtilizadorCriarDto utilizador)
        {
            IEnumerable<string> lista = ctx.GrupoDeUtilizadores.Select(g => g.Nome).ToList();
            ViewBag.ListaNomesGruposDeUtilizadores = lista;

            var email = ctx.Utilizadores.FirstOrDefault(x => x.EmailLogin == utilizador.EmailLogin);

            if (ModelState.IsValid && email == null)
            {
                CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();
                Utilizador utilizadorNovo = new Utilizador()
                {
                    Nome = utilizador.Nome,
                    GrupoDeUtilizadoresId = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Nome == utilizador.GrupoDeUtilizadores.Nome).Id,
                    EmailLogin = utilizador.EmailLogin.ToLower(),
                    PasswordLogin = codificacaoDePassword.ObterHashMD5(utilizador.PasswordLogin),
                    DataAlteracao = DateTime.Now,
                    DataCriacao = DateTime.Now
                };
                ctx.Utilizadores.Add(utilizadorNovo);
                ctx.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Criação do Cookie e Prazo de validade do Cookie
                var cookieOptions = new CookieOptions
                {
                    Expires = new DateTimeOffset(DateTime.Now.AddMinutes(30))
                };
                ViewBag.EmailExistente = "Este e-mail de utilizador já existe";
                return View();
            }
        }

        // GET: UtilizadorController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            IEnumerable<string> lista = ctx.GrupoDeUtilizadores.Select(g => g.Nome).ToList();
            ViewBag.ListaNomesGruposDeUtilizadores = lista;

            var utilizador = ctx.Utilizadores.Include("GrupoDeUtilizadores").FirstOrDefault(u => u.Id == id);
            return View(utilizador);
        }

        // POST: UtilizadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, UtilizadorEditarDto utilizadorA)
        {
            IEnumerable<string> lista = ctx.GrupoDeUtilizadores.Select(g => g.Nome).ToList();
            ViewBag.ListaNomesGruposDeUtilizadores = lista;

            if (ModelState.IsValid)
            {
                var utilizador = ctx.Utilizadores.Include("GrupoDeUtilizadores").FirstOrDefault(u => u.Id == id);

                utilizador.Nome = utilizadorA.Nome;
                utilizador.GrupoDeUtilizadoresId = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Nome == utilizadorA.GrupoDeUtilizadores.Nome).Id;
                utilizador.Ativo = utilizadorA.Ativo;
                utilizador.DataAlteracao = DateTime.Now;

                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: UtilizadorController/Edit/5
        public ActionResult EditPwd(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];
            //ViewBag.PasswordErrada = "";

            var utilizador = ctx.Utilizadores.FirstOrDefault(u => u.Id == id);
            return View(utilizador);
        }

        // POST: UtilizadorController/Edit/5
        [HttpPost]
        //[Route("pwd")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPwd(Guid id, UtilizadorPasswordDto utilizadorA)
        {
            var utilizador = ctx.Utilizadores.FirstOrDefault(u => u.Id == id);
            CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();
            var pwdNova = codificacaoDePassword.ObterHashMD5(utilizadorA.PasswordAntiga);

            if (pwdNova != utilizador.PasswordLogin)
            {
                ViewBag.PasswordErrada = "Password errada";
                return View(utilizador);
            }
            else
            {
                ViewBag.PasswordErrada = "";
                if (ModelState.IsValid)
                {
                    utilizador.PasswordLogin = codificacaoDePassword.ObterHashMD5(utilizadorA.PasswordNova);
                    utilizador.DataAlteracao = DateTime.Now;

                    ctx.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(utilizador);
                }
            }
        }

        // GET: UtilizadorController/Delete/5
        public ActionResult Delete(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var utilizador = ctx.Utilizadores.FirstOrDefault(u => u.Id == id);
            return View(utilizador);
        }

        // POST: UtilizadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var utilizador = ctx.Utilizadores.FirstOrDefault(u => u.Id == id);
                ctx.Utilizadores.Remove(utilizador);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
