using System;
using System.Collections.Generic;

namespace ConexaoBD.DAL.Repositorios
{
    public interface IRepositorio<T>
    {
        //Create
        T CriarObjeto(T objeto);

        //Read
        T LerPorId(Guid id);
        IEnumerable<T> LerTodos();

        //Update
        T AtualizarObjeto(T alteracoes);

        //Delete
        T EliminarPorId(Guid id);
    }
}
