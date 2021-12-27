using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoBD.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //CRUD de acesso à Base de Dados:
        readonly ConexaoBDContexto ctx;
        public ClienteController()
        {
            ctx = new ConexaoBDContexto();
        }

        //Create
        [HttpPost]
        public Guid PostClienteNovo(string nome, string nif, TipoMorada tipoMorada, string distrito, string endereco, string codPostal, string localidade)
        {
            var clienteNovo = new Cliente
            {
                Nome = nome,
                NIF = nif,
                MoradaCliente = new Morada()
                {
                    TipoMorada = tipoMorada,
                    Distrito = distrito,
                    Endereco = endereco,
                    CodigoPostal = codPostal,
                    Localidade = localidade
                }
            };
            ctx.Clientes.Add(clienteNovo);
            ctx.SaveChanges();
            return clienteNovo.Id;
        }

        //Read
        [HttpGet]
        public List<Cliente> GetTodosOsClientes()
        {
            return ctx.Clientes.Include("MoradaCliente").ToList();
        }

        //[HttpGet("{nome}")]
        //public Cliente GetClientePorNome(string nome)
        //{
        //    return ctx.Clientes.FirstOrDefault(x => x.Nome == nome);
        //}

        //[HttpGet("{nif}")]
        //public Cliente GetClientePorNif(string nif)
        //{
        //    return ctx.Clientes.FirstOrDefault(x => x.NIF == nif);
        //}

        //Não podemos ter duas buscas do mesmo tipo(escolher procura por nome ou por nif ou por outra qualquer)
        [HttpGet("{inicioNome}")]
        public Cliente GetClientePorNomeComecadoPor(string inicioNome)
        {
            return ctx.Clientes.FirstOrDefault(c => c.Nome.StartsWith(inicioNome));
        }

        //[HttpGet]
        //public int GetNumeroDeClientes()
        //{
        //    var soma = ctx.Clientes.Where(c => c.Ativo == true).Count();
        //    return soma;
        //}


        //Update
        [HttpPut]
        public bool UpdateClientePorNomeComecadoPor(string inicioNome, ClienteDto dadosNovos)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Nome.StartsWith(inicioNome));
            if (cliente == null)
            {
                return false;
            }
            else
            {
                cliente.Nome = dadosNovos.Nome;
                cliente.NIF = dadosNovos.NIF;
                cliente.Ativo = dadosNovos.Ativo;
                cliente.DataAlteracao = DateTime.Now;
                cliente.MoradaCliente.TipoMorada = dadosNovos.TipoMorada;
                cliente.MoradaCliente.Distrito = dadosNovos.Distrito;
                cliente.MoradaCliente.Endereco = dadosNovos.Endereco;
                cliente.MoradaCliente.CodigoPostal = dadosNovos.CodigoPostal;
                cliente.MoradaCliente.Localidade = dadosNovos.Localidade;
            }
            ctx.SaveChanges();
            return true;
        }

        //Delete
        [HttpDelete]
        public bool DeleteClientePorNome(string inicioNome)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(c => c.Nome.StartsWith(inicioNome));
            if (cliente == null)
            {
                return false;
            }
            var idMorada = cliente.MoradaCliente.Id;
            var morada = ctx.Moradas.FirstOrDefault(n => n.Id == idMorada);
            ctx.Clientes.Remove(cliente);
            ctx.Moradas.Remove(morada);
            ctx.SaveChanges();
            return true;
        }

    }
}
