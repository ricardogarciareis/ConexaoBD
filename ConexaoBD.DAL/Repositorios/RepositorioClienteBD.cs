using ConexaoBD.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoBD.DAL.Repositorios
{
    public class RepositorioClienteBD : IRepositorio<Cliente>
    //public class RepositorioClienteBD : IRepositorioCliente
    {
        //Vídeo 49 - 7:00
        private readonly ConexaoBDContexto _ctx;

        public RepositorioClienteBD(ConexaoBDContexto ctx)
        {
            this._ctx = ctx;
        }

        //Create
        public Cliente CriarObjeto(Cliente objeto)
        {
            _ctx.Clientes.Add(objeto);
            _ctx.SaveChanges();
            return objeto;
        }

        //Read
        public IEnumerable<Cliente> LerTodos()
        {
            var lista = _ctx.Clientes;
            return lista;
        }

        public Cliente LerPorId(Guid id)
        {
            var cliente = _ctx.Clientes.Find(id);
            return cliente;
        }

        //Update
        public Cliente AtualizarObjeto(Cliente alteracoes)
        {
            var cliente = _ctx.Clientes.Attach(alteracoes);
            cliente.State = EntityState.Modified;
            _ctx.SaveChanges();
            return alteracoes;
        }

        //Delete
        public Cliente EliminarPorId(Guid id)
        {
            var cliente = _ctx.Clientes.Find(id);
            if (cliente != null)
            {
                _ctx.Clientes.Remove(cliente);
                _ctx.SaveChanges();
            }
            return cliente;
        }
    }
}
