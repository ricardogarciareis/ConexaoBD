using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Repositorios;

namespace ConexaoBD.DAL.Tests
{
    [TestClass]
    public class UtilizadorTests
    {
        [TestMethod]
        public void DeveCriarUmObjetoDoTipoRepositorioUtilizador()
        {
            //Arrange
            RepositorioUtilizador repo;

            //Act
            repo = new RepositorioUtilizador();

            //Assert
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void DeveCriarUmaListaDeUtilizadorNoObjetoRepositorioUtilizador()
        {
            //Arrange
            RepositorioUtilizador repo = new RepositorioUtilizador();
            List<Utilizador> lista;

            //Act
            lista = repo.LerTodos();

            //Assert
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void DeveVerificarConteudoNaoNuloDoObjetoRepositorioUtilizador()
        {
            //Arrange
            RepositorioUtilizador repo = new RepositorioUtilizador();
            List<Utilizador> lista = repo.LerTodos();
            int minElementos = 1;

            //Act
            int qtdElementosLista = lista.Count;

            //Assert
            Assert.IsTrue(qtdElementosLista >= minElementos);
        }

        [TestMethod]
        public void DeveCriarUmNovoUtilizadorNoObjetoRepositorioUtilizador()
        {
            //Arrange
            RepositorioUtilizador repo = new RepositorioUtilizador();
            List<Utilizador> lista = repo.LerTodos();
            var qtdUtilizadoresInicial = lista.Count;
            Utilizador utilizador;

            //Act
            utilizador = new Utilizador()
            {
                Nome = "Nome de utilizador 3",
                EmailLogin = "jose.carlos@intranet.rr",
                PasswordLogin = "12_"
            };
            repo.CriarObjeto(utilizador);
            lista = repo.LerTodos();
            var qtdUtilizadoresFinal = lista.Count;

            //Assert
            Assert.IsTrue(qtdUtilizadoresFinal > qtdUtilizadoresInicial);
        }

        [DataTestMethod]
        [DataRow("Nome de utilizador 1")]
        public void DeveProcurarUmUtilizadorPorNome(string nome)
        {
            //Arrange
            RepositorioUtilizador repo = new RepositorioUtilizador();
            Utilizador utilizador;

            //Act
            utilizador = repo.LerPorNome(nome);

            //Assert
            Assert.IsTrue(utilizador.Nome == nome);
        }

        [DataTestMethod]
        [DataRow("Nome de utilizador 1")]
        public void DeveEliminarUmUtilizadorPorNome(string nome)
        {
            //Arrange
            RepositorioUtilizador repo = new RepositorioUtilizador();
            Utilizador utilizador;

            //Act
            repo.EliminarPorProcuraNome(nome);
            utilizador = repo.LerPorNome(nome);

            //Assert
            Assert.IsTrue(utilizador == null);
        }

    }
}
