using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Model.Dto.GrupoDeUtilizadores;
using ConexaoBD.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ConexaoBD.WEB.MVC.Controllers
{
    public class GrupoUtilizadoresController : Controller
    {
        //CRUD de acesso à Base de Dados:
        private readonly ConexaoBDContexto ctx;
        public GrupoUtilizadoresController(ConexaoBDContexto _ctx)
        {
            ctx = _ctx;
        }


        public ActionResult Index()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            if (ViewBag.ClienteLogado != "")
            {
                var gruposDeUtilizadores = ctx.GrupoDeUtilizadores.OrderBy(c => c.Nome);
                //DBCC CHECKIDENT (GrupoDeUtilizadores, RESEED, 0)
                if (gruposDeUtilizadores.Count() == 0)
                {
                    var admin = new GrupoDeUtilizadores()
                    {
                        Nome = "Admin",
                        TipoDeGrupoDeUtilizadores = "Administradores",
                        Ativo = true,
                        DataAlteracao = DateTime.Now,
                        DataCriacao = DateTime.Now
                    };
                    ctx.GrupoDeUtilizadores.Add(admin);
                    ctx.SaveChanges();
                }
                var utilizadores = ctx.Utilizadores.OrderBy(u => u.Nome);
                CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();
                if (utilizadores.Count() == 0)
                {
                    var admin = new Utilizador()
                    {
                        Nome = "Admin",
                        EmailLogin = "admin@intranet.rr",
                        PasswordLogin = codificacaoDePassword.ObterHashMD5("123456"),
                        Ativo = true,
                        GrupoDeUtilizadoresId = 1
                    };
                    ctx.Utilizadores.Add(admin);
                    ctx.SaveChanges();
                }

                return View(gruposDeUtilizadores);
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var grupoDeUtilizador = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Id == id);
            return View(grupoDeUtilizador);
        }

        public ActionResult Create()
        {
            var grupoDeUtilizador = new GrupoDeUtilizadores
            {
                //Pré-Definições:

            };
            return View(grupoDeUtilizador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GrupoDeUtilizadores grupo)
        {
            if (ModelState.IsValid)
            {
                GrupoDeUtilizadores grupoNovo = new GrupoDeUtilizadores()
                {
                    Nome = grupo.Nome,
                    TipoDeGrupoDeUtilizadores = grupo.TipoDeGrupoDeUtilizadores,
                    Ativo = true,
                    DataAlteracao = DateTime.Now,
                    DataCriacao = DateTime.Now
                };
                ctx.GrupoDeUtilizadores.Add(grupoNovo);
                ctx.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var grupoDeUtilizador = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Id == id);
            return View(grupoDeUtilizador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GrupoDeUtilizadoresDto grupoA)
        {
            if (ModelState.IsValid)
            {
                var grupoDeUtilizador = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Id == id);

                grupoDeUtilizador.Nome = grupoA.Nome;
                grupoDeUtilizador.TipoDeGrupoDeUtilizadores = grupoA.TipoDeGrupoDeUtilizadores;
                grupoDeUtilizador.Ativo = grupoA.Ativo;
                grupoDeUtilizador.DataAlteracao = DateTime.Now;

                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var grupoDeUtilizador = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Id == id);
            return View(grupoDeUtilizador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var grupoDeUtilizador = ctx.GrupoDeUtilizadores.FirstOrDefault(g => g.Id == id);
                ctx.GrupoDeUtilizadores.Remove(grupoDeUtilizador);
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
