using System.Collections.Generic;

namespace ConexaoBD.DAL.Repositorios
{
    interface IRepositorio<T>
    {
        //Create
        void CriarObjeto(T objeto);

        //Read
        T LerPorNome(string nome);
        List<T> LerTodos();

        //Update
        T AtualizarNomeProcuraNome(string nomeAntigo, string nomeNovo);

        //Delete
        void EliminarPorProcuraNome(string nome);
        void EliminarTodos();
    }
}
