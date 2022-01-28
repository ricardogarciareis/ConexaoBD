using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoBD.DAL.Repositorios
{
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        //Criação de Lista
        private List<Cliente> ListaClientes;

        //Create
        public void CriarObjeto(Cliente objeto)
        {
            ListaClientes.Add(objeto);
        }

        //Read
        public Cliente LerPorNome(string nome)
        {
            var resultado = ListaClientes
                .Where(x => x.Nome == nome)
                .OrderBy(x => x.NIF)
                .FirstOrDefault();
            if (resultado == null)
            {
                Console.WriteLine($"O cliente '{nome}' não existe no repositório de clientes.");
            }
            return resultado;
        }

        public Cliente LerPorNif(string nif)
        {
            var resultado = ListaClientes
                .Where(x => x.NIF == nif)
                .FirstOrDefault();
            if (resultado == null)
            {
                Console.WriteLine($"O cliente com o NIF '{nif}' não existe no repositório de clientes.");
            }
            return resultado;
        }

        public List<Cliente> LerTodos()
        {
            if (ListaClientes.Count() == 0)
            {
                Console.WriteLine($"O repositório de clientes está vazio.");
            }
            return ListaClientes;
        }

        //Update
        public Cliente AtualizarNomeProcuraNome(string nomeAntigo, string nomeNovo)
        {
            var clienteTemp = LerPorNome(nomeAntigo);
            if (clienteTemp != null)
            {
                clienteTemp.Nome = nomeNovo;
                return clienteTemp;
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                return null;
            }
        }

        public Cliente AtualizarNomeProcuraNIF(string nif, string nomeNovo)
        {
            var clienteTemp = LerPorNif(nif);
            if (clienteTemp != null)
            {
                clienteTemp.Nome = nomeNovo;
            }
            return clienteTemp;
        }

        public Cliente AtualizarNifProcuraNome(string nome, string nifNovo) 
        {
            var clienteTemp = LerPorNome(nome);
            if (clienteTemp != null)
            {
                if (nifNovo.Length == 9 && nifNovo.All(char.IsDigit))
                {
                    clienteTemp.NIF = nifNovo;
                    Console.WriteLine("NIF do cliente alterado com sucesso.");
                    return clienteTemp;
                }
                else
                {
                    Console.WriteLine("O NIF deve conter exatamente 9 carateres numéricos.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                return null;
            }
        }

        public Cliente AtualizarNifProcuraNif(string nifAntigo, string nifNovo)
        {
            var clienteTemp = LerPorNif(nifAntigo);
            if (clienteTemp != null)
            {
                if (nifNovo.Length == 9 && nifNovo.All(char.IsDigit))
                {
                    clienteTemp.NIF = nifNovo;
                    return clienteTemp;
                }
                else
                {
                    Console.WriteLine("O NIF deve conter exatamente 9 carateres numéricos.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                return null;
            }
        }

        //Delete
        private void EliminarObjeto(Cliente objeto) //Utilização apenas dentro desta classe
        {
            if (objeto != null)
            {
                ListaClientes.Remove(objeto);
                Console.WriteLine($"Cliente removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Objeto não encontrado.");
            }
        }

        public void EliminarPorProcuraNome(string nome)
        {
            var clienteAEliminar = LerPorNome(nome);
            if (clienteAEliminar != null)
            {
                ListaClientes.Remove(clienteAEliminar);
                Console.WriteLine($"Cliente removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        public void EliminarPorProcuraNif(string nif)
        {
            var clienteAEliminar = LerPorNif(nif);
            if (clienteAEliminar != null)
            {
                ListaClientes.Remove(clienteAEliminar);
                Console.WriteLine($"Cliente removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        public void EliminarTodos()
        {
            ListaClientes.Clear();
            Console.WriteLine($"Clientes removidos do repositório com sucesso.");
        }

        public RepositorioCliente()
        {
            ListaClientes = new List<Cliente>();
            var cliente0 = new Cliente
            {
                Nome = "Nome de cliente 0",
                NIF = "111111110",
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Principal,
                    TipoDeMorada = TipoMorada.Principal.ToString(),
                    Distrito = "Lisboa",
                    Endereco = "Rua das Casas, 1",
                    CodigoPostal = "1111",
                    ZonaPostal = "222",
                    Localidade = "Alverca"
                }
            };
            ListaClientes.Add(cliente0);

            var cliente1 = new Cliente
            {
                Nome = "Nome de cliente 1",
                NIF = "111111111",
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Sede,
                    TipoDeMorada = TipoMorada.Sede.ToString(),
                    Distrito = "Porto",
                    Endereco = "Rua das Hortas, 2",
                    CodigoPostal = "2222",
                    ZonaPostal = "333",
                    Localidade = "Boavista"
                }
            };
            ListaClientes.Add(cliente1);

            var cliente2 = new Cliente
            {
                Nome = "Nome de cliente 2",
                NIF = "111111112",
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Sede,
                    TipoDeMorada = TipoMorada.Sede.ToString(),
                    Distrito = "Coimbra",
                    Endereco = "Rua das Estradas, 3",
                    CodigoPostal = "3333",
                    ZonaPostal = "333",
                    Localidade = "Coimbra"
                }
            };
            ListaClientes.Add(cliente2);


            EliminarObjeto(cliente2);
            //EliminarTodos();
        } 
    }
}
