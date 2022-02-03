using ConexaoBD.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConexaoBD.DAL.Repositorios
{
    public class RepositorioClienteMemoria : IRepositorio<Cliente>
    {


        //Criação de Lista
        private List<Cliente> _listaClientes;

        public RepositorioClienteMemoria()
        {
            _listaClientes = new List<Cliente>();
            var cliente0 = new Cliente
            {
                Nome = "Nome de cliente 0",
                NIF = "111111110",
                DataNascimento = new DateTime(2015, 12, 31),
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
            _listaClientes.Add(cliente0);

            var cliente1 = new Cliente
            {
                Nome = "Nome de cliente 1",
                NIF = "111111111",
                DataNascimento = new DateTime(2010, 01, 31),
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
            _listaClientes.Add(cliente1);

            var cliente2 = new Cliente
            {
                Nome = "Nome de cliente 2",
                NIF = "111111112",
                DataNascimento = new DateTime(2005, 06, 15),
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
            _listaClientes.Add(cliente2);


            //EliminarObjeto(cliente2);
            //EliminarTodos();
        }


        //Métodos Personalizados

        //Create
        public void CriarObjetoLista(Cliente objeto)
        {
            _listaClientes.Add(objeto);
        }

        //Read
        public Cliente LerPorNomeLista(string nome)
        {
            var resultado = _listaClientes
                .Where(x => x.Nome == nome)
                .OrderBy(x => x.NIF)
                .FirstOrDefault();
            if (resultado == null)
            {
                Console.WriteLine($"O cliente '{nome}' não existe no repositório de clientes.");
            }
            return resultado;
        }

        public Cliente LerPorNifLista(string nif)
        {
            var resultado = _listaClientes
                .Where(x => x.NIF == nif)
                .FirstOrDefault();
            if (resultado == null)
            {
                Console.WriteLine($"O cliente com o NIF '{nif}' não existe no repositório de clientes.");
            }
            return resultado;
        }

        public List<Cliente> LerTodosLista()
        {
            if (_listaClientes.Count() == 0)
            {
                Console.WriteLine($"O repositório de clientes está vazio.");
            }
            return _listaClientes;
        }

        //Update
        public Cliente AtualizarNomeProcuraNomeLista(string nomeAntigo, string nomeNovo)
        {
            var clienteTemp = LerPorNomeLista(nomeAntigo);
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

        public Cliente AtualizarNomeProcuraNIFLista(string nif, string nomeNovo)
        {
            var clienteTemp = LerPorNifLista(nif);
            if (clienteTemp != null)
            {
                clienteTemp.Nome = nomeNovo;
            }
            return clienteTemp;
        }

        public Cliente AtualizarNifProcuraNomeLista(string nome, string nifNovo) 
        {
            var clienteTemp = LerPorNomeLista(nome);
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

        public Cliente AtualizarNifProcuraNifLista(string nifAntigo, string nifNovo)
        {
            var clienteTemp = LerPorNifLista(nifAntigo);
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
        private void EliminarObjetoLista(Cliente objeto) //Utilização apenas dentro desta classe
        {
            if (objeto != null)
            {
                _listaClientes.Remove(objeto);
                Console.WriteLine($"Cliente removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Objeto não encontrado.");
            }
        }

        public void EliminarPorProcuraNomeLista(string nome)
        {
            var clienteAEliminar = LerPorNomeLista(nome);
            if (clienteAEliminar != null)
            {
                _listaClientes.Remove(clienteAEliminar);
                Console.WriteLine($"Cliente removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        public void EliminarPorProcuraNifLista(string nif)
        {
            var clienteAEliminar = LerPorNifLista(nif);
            if (clienteAEliminar != null)
            {
                _listaClientes.Remove(clienteAEliminar);
                Console.WriteLine($"Cliente removido da Base de Dados com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        public void EliminarTodosLista()
        {
            _listaClientes.Clear();
            Console.WriteLine($"Clientes removidos do repositório com sucesso.");
        }


        //Implementação
        public Cliente CriarObjeto(Cliente objeto)
        {
            _listaClientes.Add(objeto);
            return objeto;
        }

        public Cliente LerPorId(Guid id)
        {
            var cliente = _listaClientes.FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public IEnumerable<Cliente> LerTodos()
        {
            return _listaClientes;
        }

        public Cliente AtualizarObjeto(Cliente alteracoes)
        {
            var cliente = _listaClientes.FirstOrDefault(c => c.Id == alteracoes.Id);
            if (cliente != null)
            {
                cliente.Nome = alteracoes.Nome;
                cliente.NIF = alteracoes.NIF;
                cliente.DataNascimento = alteracoes.DataNascimento;
                cliente.Ativo = alteracoes.Ativo;
                cliente.MoradaCliente.TipoMorada = alteracoes.MoradaCliente.TipoMorada;
                cliente.MoradaCliente.TipoDeMorada = alteracoes.MoradaCliente.TipoDeMorada;
                cliente.MoradaCliente.Distrito = alteracoes.MoradaCliente.Distrito;
                cliente.MoradaCliente.Endereco = alteracoes.MoradaCliente.Endereco;
                cliente.MoradaCliente.CodigoPostal = alteracoes.MoradaCliente.CodigoPostal;
                cliente.MoradaCliente.ZonaPostal = alteracoes.MoradaCliente.ZonaPostal;
                cliente.MoradaCliente.Localidade = alteracoes.MoradaCliente.Localidade;
                cliente.DataAlteracao = DateTime.Now;
                cliente.DataCriacao = cliente.DataCriacao;
                Console.WriteLine($"Cliente alterado no repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            return cliente;
        }

        public Cliente EliminarPorId(Guid id)
        {
            var cliente = _listaClientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _listaClientes.Remove(cliente);
                Console.WriteLine($"Cliente removido do repositório com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            return cliente;
        }
    }
}
