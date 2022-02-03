using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;



namespace ConexaoBD.WEB.MVC.Controllers
{
    public class ClienteController : Controller
    {
        //CRUD de acesso à Base de Dados:
        private readonly ConexaoBDContexto _ctx;

        private IRepositorio<Cliente> _repositorioClienteBD;

        public ClienteController(ConexaoBDContexto ctx, IRepositorio<Cliente> repositorioClienteBD)
        {
            _ctx = ctx;
            _repositorioClienteBD = repositorioClienteBD;
        }



        public ActionResult Index()
        {
            var clientes = _ctx.Clientes.Include("MoradaCliente").OrderBy(c => c.Nome);
            return View(clientes);
        }


        public ActionResult Details(Guid id)
        {
            var cliente = _ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
            return View(cliente);
        }


        public ActionResult Create()
        {
            var cliente = new Cliente
            {
                //Pré-Definições:
                NIF = "123456789",
                DataNascimento = new DateTime(2000, 01, 01),
                MoradaCliente = new Morada()
                {
                    CodigoPostal = "0000",
                    ZonaPostal = "000"
                }
            };
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.CriadoPor = User.Identity.Name;
                cliente.AlteradoPor = User.Identity.Name;
                Cliente novoCliente = _repositorioClienteBD.CriarObjeto(cliente);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(cliente);
            }
        }


        public ActionResult Edit(Guid id)
        {
            var cliente = _ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente model)
        {
            if (ModelState.IsValid)
            {
                var cliente = _repositorioClienteBD.LerPorId(model.Id);
                cliente.Nome = model.Nome;
                cliente.NIF = model.NIF;
                cliente.DataNascimento = model.DataNascimento;
                cliente.Ativo = model.Ativo;
                cliente.DataAlteracao = DateTime.Now;
                cliente.AlteradoPor = User.Identity.Name;
                cliente.Ficheiro = model.Ficheiro;

                _repositorioClienteBD.AtualizarObjeto(cliente);

                var morada = _ctx.Moradas.FirstOrDefault(m => m.Id == model.MoradaCliente.Id);
                morada.TipoDeMorada = model.MoradaCliente.TipoDeMorada;
                morada.Distrito = model.MoradaCliente.Distrito;
                morada.Endereco = model.MoradaCliente.Endereco;
                morada.CodigoPostal = model.MoradaCliente.CodigoPostal;
                morada.ZonaPostal = model.MoradaCliente.ZonaPostal;
                morada.Localidade = model.MoradaCliente.Localidade;

                _ctx.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var cliente = _ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var cliente = _ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Id == id);
                var morada = _ctx.Moradas.FirstOrDefault(m => m.Id == cliente.MoradaCliente.Id);
                _ctx.Moradas.Remove(morada);
                _ctx.Clientes.Remove(cliente);
                _ctx.SaveChanges();
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