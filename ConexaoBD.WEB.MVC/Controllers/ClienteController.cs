using ConexaoBD.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;



namespace ConexaoBD.WEB.MVC.Controllers
{
    public class ClienteController : Controller
    {
        //CRUD de acesso à Base de Dados:
        private readonly ConexaoBDContexto ctx;

        public ClienteController() // Funciona
        {
            ctx = new ConexaoBDContexto();

        }

        //public ClienteController(ConexaoBDContexto _ctx)
        //{
        //    ctx = _ctx;
        //}


        // GET: ClienteController
        public ActionResult Index()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            if(ViewBag.ClienteLogado != "")
            {
                var clientes = ctx.Clientes.Include("MoradaCliente").OrderBy(c => c.Nome);
                return View(clientes);
            }
            return View();
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var cliente = new Cliente
            {
                //Pré-Definições:
                NIF = "123456789",
                MoradaCliente = new Morada()
                {
                    CodigoPostal = "0000",
                    ZonaPostal = "000"
                }
            };
            return View(cliente);
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            try
            {
                Cliente clienteNovo = new Cliente()
                {
                    NIF = cliente.NIF,
                    Nome = cliente.Nome,
                    DataAlteracao = DateTime.Now,
                    AlteradoPor = ViewBag.ClienteLogado,
                    DataCriacao = DateTime.Now,
                    CriadoPor = ViewBag.ClienteLogado,
                    DataNascimento = cliente.DataNascimento,
                    MoradaCliente = new Morada()
                    {
                        TipoDeMorada = cliente.MoradaCliente.TipoDeMorada,
                        Distrito = cliente.MoradaCliente.Distrito,
                        Endereco = cliente.MoradaCliente.Endereco,
                        CodigoPostal = cliente.MoradaCliente.CodigoPostal,
                        ZonaPostal = cliente.MoradaCliente.ZonaPostal,
                        Localidade = cliente.MoradaCliente.Localidade
                    },
                    Ficheiro = cliente.Ficheiro
                };
                ctx.Clientes.Add(clienteNovo);
                ctx.SaveChanges();

                return RedirectToAction(nameof(Index));
            } catch
            {
                return View(cliente);
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(Guid id, IFormCollection collection)
        public ActionResult Edit(Guid id, Cliente clienteA)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            try
            {
                var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);

                cliente.Id = cliente.Id;
                cliente.Nome = clienteA.Nome;
                cliente.NIF = clienteA.NIF;
                cliente.DataNascimento = clienteA.DataNascimento;
                cliente.Ativo = clienteA.Ativo;
                cliente.DataAlteracao = DateTime.Now;
                cliente.AlteradoPor = ViewBag.ClienteLogado;
                cliente.Ficheiro = clienteA.Ficheiro;
                //if(clienteA.Ficheiro.Length > 0)
                //{
                //    //string filename = Path.GetFileName(clienteA.Ficheiro) + "_" + DateTime.Now.ToShortDateString() + Path.GetExtension(clienteA.Ficheiro);
                //    //string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles"));
                //    //using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                //    {
                //        //clienteA.Ficheiro.CopyTo(new FileStream(path, FileMode.Create));
                //    }
                //}

                cliente.MoradaCliente.Id = cliente.MoradaCliente.Id;
                cliente.MoradaCliente.TipoDeMorada = clienteA.MoradaCliente.TipoDeMorada;
                cliente.MoradaCliente.Distrito = clienteA.MoradaCliente.Distrito;
                cliente.MoradaCliente.Endereco = clienteA.MoradaCliente.Endereco;
                cliente.MoradaCliente.CodigoPostal = clienteA.MoradaCliente.CodigoPostal;
                cliente.MoradaCliente.ZonaPostal = clienteA.MoradaCliente.ZonaPostal;
                cliente.MoradaCliente.Localidade = clienteA.MoradaCliente.Localidade;
                
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(Guid id)
        {
            ViewBag.ClienteLogado = HttpContext.Request.Cookies["NomeDoUtilizador"];

            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
                var morada = ctx.Moradas.FirstOrDefault(m => m.Id == cliente.MoradaCliente.Id);
                ctx.Moradas.Remove(morada);
                ctx.Clientes.Remove(cliente);
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
//Cliente de teste:
//INSERT INTO Clientes (Id, NIF, Nome, DataNascimento) VALUES('69c95a2f-b40c-49ea-b99f-73531290c5e2', '111111111', 'Cliente para Apagar', '1999-01-01')
//INSERT INTO Moradas (TipoMorada, Distrito, Endereco, CodigoPostal, Localidade) VALUES(0, 'Viseu', 'Rua dos Testes', '1234567', 'Teste')
//UPDATE Clientes SET MoradaClienteId = 14 WHERE Nome = 'Cliente para Apagar_'