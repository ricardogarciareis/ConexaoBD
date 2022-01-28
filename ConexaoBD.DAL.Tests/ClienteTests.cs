using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConexaoBD.DAL.Tests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void DeveCriarUmObjetoDoTipoRepositorioCliente()
        {
            //Arrange
            RepositorioCliente repo;

            //Act
            repo = new RepositorioCliente();

            //Assert
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void DeveCriarUmaListaDeClienteNoObjetoRepositorioCliente()
        {
            //Arrange
            RepositorioCliente repo = new RepositorioCliente();
            List<Cliente> lista;

            //Act
            lista = repo.LerTodos();

            //Assert
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void DeveVerificarConteudoNaoNuloDoObjetoRepositorioCliente()
        {
            //Arrange
            RepositorioCliente repo = new RepositorioCliente();
            List<Cliente> lista = repo.LerTodos();
            int minElementos = 1;

            //Act
            int qtdElementosLista = lista.Count;

            //Assert
            Assert.IsTrue(qtdElementosLista >= minElementos);
        }

        [TestMethod]
        public void DeveCriarUmNovoClienteNoObjetoRepositorioCliente()
        {
            //Arrange
            RepositorioCliente repo = new RepositorioCliente();
            List<Cliente> lista = repo.LerTodos();
            var qtdClientesInicial = lista.Count;
            Cliente cliente;

            //Act
            cliente = new Cliente() {
                Nome = "Nome de cliente 3",
                NIF = "111111114",
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Sede,
                    TipoDeMorada = TipoMorada.Sede.ToString(),
                    Distrito = "Castelo Branco",
                    Endereco = "Rua dos Eucaliptos, 2",
                    CodigoPostal = "5555",
                    ZonaPostal = "111",
                    Localidade = "Oleiros"
                },
                DataNascimento = new DateTime(2008, 5, 1, 0, 0, 0)
            };
            repo.CriarObjeto(cliente);
            lista = repo.LerTodos();
            var qtdClientesFinal = lista.Count;

            //Assert
            Assert.IsTrue(qtdClientesFinal > qtdClientesInicial);
        }

        [DataTestMethod]
        [DataRow("Nome de cliente 1")]
        public void DeveProcurarUmClientePorNome(string nome)
        {
            //Arrange
            RepositorioCliente repo = new RepositorioCliente();
            Cliente cliente;

            //Act
            cliente = repo.LerPorNome(nome);

            //Assert
            Assert.IsTrue(cliente.Nome == nome);
        }

        [DataTestMethod]
        [DataRow("Nome de cliente 1")]
        public void DeveEliminarUmClientePorNome(string nome)
        {
            //Arrange
            RepositorioCliente repo = new RepositorioCliente();
            Cliente cliente;

            //Act
            repo.EliminarPorProcuraNome(nome);
            cliente = repo.LerPorNome(nome);

            //Assert
            Assert.IsTrue(cliente == null);
        }

    }
}

//Best practices: https://www.testim.io/blog/unit-testing-best-practices/
//Shouldly: https://docs.shouldly.io/documentation/getting-started