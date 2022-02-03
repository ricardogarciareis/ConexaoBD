using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;

namespace ConexaoBD.DAL.Repositorios
{
    public interface IRepositorioCliente
    {
        //Create
        Cliente CriarObjeto(Cliente objeto);

        //Read
        Cliente LerPorId(Guid id);
        IEnumerable<Cliente> LerTodos();

        //Update
        Cliente AtualizarObjeto(Cliente alteracoes);

        //Delete
        Cliente EliminarPorId(Guid id);
    }
}
