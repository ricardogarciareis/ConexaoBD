using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoBD.DAL.Repositorios
{
    public class RepositorioUtilizador : IRepositorio<Utilizador>
    {
        //Criação de Lista
        private List<Utilizador> ListaUtilizadores;

        //Create
        public void CriarObjeto(Utilizador objeto)
        {
            ListaUtilizadores.Add(objeto);
        }

        //Read
        public Utilizador LerPorNome(string nome)
        {
            var resultado = ListaUtilizadores
                .Where(x => x.Nome == nome)
                .OrderBy(x => x.Nome)
                .FirstOrDefault();
            if (resultado == null)
            {
                Console.WriteLine($"O utilizador '{nome}' não existe no repositório de utilizadores.");
            }
            return resultado;
        }

        public List<Utilizador> LerTodos()
        {
            if (ListaUtilizadores.Count() == 0)
            {
                Console.WriteLine($"O repositório de utilizadores está vazio.");
            }
            return ListaUtilizadores;
        }

        //Update
        public Utilizador AtualizarNomeProcuraNome(string nomeAntigo, string nomeNovo)
        {
            var utiliadorTemp = LerPorNome(nomeAntigo);
            if (utiliadorTemp != null)
            {
                utiliadorTemp.Nome = nomeNovo;
                return utiliadorTemp;
            }
            else
            {
                Console.WriteLine("Utilizador não encontrado.");
                return null;
            }
        }

        public Utilizador AtualizarEmailProcuraNome(string nome, string emailNovo)
        {
            var utilizadorTemp = LerPorNome(nome);
            if (utilizadorTemp != null)
            {
                utilizadorTemp.EmailLogin = emailNovo;
                return utilizadorTemp;
            }
            else
            {
                Console.WriteLine("Nome de utilizador não encontrado.");
                return null;
            }
        }

        public Utilizador AtualizarSenhaProcuraNome(string nome, string senhaNova)
        {
            var utilizadorTemp = LerPorNome(nome);
            if (utilizadorTemp != null)
            {
                utilizadorTemp.PasswordLogin = senhaNova;
                return utilizadorTemp;
            }
            else
            {
                Console.WriteLine("Nome de utilizador não encontrado.");
                return null;
            }
        }

        //Delete
        private void EliminarObjeto(Utilizador objeto) //Utilização apenas dentro desta classe
        {
            if (objeto != null)
            {
                ListaUtilizadores.Remove(objeto);
                Console.WriteLine($"Utilizador removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Objeto não encontrado.");
            }
        }

        public void EliminarPorProcuraNome(string nome)
        {
            var utilizadorAEliminar = LerPorNome(nome);
            if (utilizadorAEliminar != null)
            {
                ListaUtilizadores.Remove(utilizadorAEliminar);
                Console.WriteLine($"Utilizador removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Utilizador não encontrado.");
            }
        }

        public void EliminarTodos()
        {
            ListaUtilizadores.Clear();
            Console.WriteLine($"Utilizadores removidos do repositório com sucesso.");
        }



        public RepositorioUtilizador()
        {
            ListaUtilizadores = new List<Utilizador>();

            var utilizador0 = new Utilizador
            {
                Nome = "Nome de utilizador 0",
                EmailLogin = "ricardo.reis@intranet.rr",
                PasswordLogin = "12345"
            };
            ListaUtilizadores.Add(utilizador0);

            var utilizador1 = new Utilizador
            {
                Nome = "Nome de utilizador 1",
                EmailLogin = "ana.costa@intranet.rr",
                PasswordLogin = "123"
            };
            ListaUtilizadores.Add(utilizador1);

            var utilizador2 = new Utilizador
            {
                Nome = "Nome de utilizador 2",
                EmailLogin = "mariana.costa@intranet.rr",
                PasswordLogin = "1234"
            };
            ListaUtilizadores.Add(utilizador2);


            EliminarObjeto(utilizador2);
            //EliminarTodos();
        }
    }
}