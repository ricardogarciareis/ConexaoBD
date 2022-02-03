using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace ConexaoBD.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------------------------------------------------------------------------
            //Playground do CRUD do RepositorioCliente
            //CriarClienteNovo();
            //CriarClienteNovo2();

            //ListarClientePorNome("Nome de cliente 1");
            //ListarClientePorNif("111111110");
            //ListarClientePorId(new Guid());
            //ListarTodosOsClientes();
            //ListarTodosOsClientes2();

            //AtualizarNomeDeClienteProcuraPorNome("Nome de cliente 0", "Ricardo");
            //AtualizarNomeDeClienteProcuraPorNif("111111111", "Ana");
            //AtualizarNifDeClienteProcuraPorNome("Nome de cliente 0", "222333445");
            //AtualizarNifDeClienteProcuraPorNif("111111111", "333444555");

            //EliminarClientePorNome("Nome de cliente 0");
            //EliminarClientePorNif("111111111");
            //EliminarTodosOsClientes();

            //------------------------------------------------------------------------------------------------------
            //Playground do CRUD do acesso à Base de Dados
            //var ctx = new ConexaoBDContexto(); /*------------------------Descomentar*/
            //CriarClienteNovo(ctx);
            //CriarUtilizadorNovo(ctx);

            //ListarTodosOsClientes(ctx, true);
            //ListarClientesAtivos(ctx, false);
            //ListarClientesComNIF(ctx, "111111113", false);
            //ListarClientesComNomeComecado(ctx, "Ri", false);
            //ListarClientesComNomeQueContem(ctx, "A.G.", false);
            //ListarTodosOsUtilizadores(ctx);

            //AtualizarEstadoDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", true);
            //AtualizarNomeDeClienteComNIF(ctx, "111111110", "Ana M.R.G. dos Reis");
            //AtualizarNomeDeClienteComNome(ctx, "Ricardo A.G. Reis", "António J.P.A. dos Reis");
            //AtualizarNomeDeClienteComNomeComecado(ctx, "Ric", "Ricardo A.G. dos Reis");
            //AtualizarNifDeClienteComNomeComecado(ctx, "Ric", "111111115");
            //AtualizarNomeDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", "Ricardo A.G. dos Reis");
            //AtualizarNifDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111110", "111111114");
            //AtualizarTipoMoradaDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", TipoMorada.Secundária);
            //AtualizarDistritoDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", "Guarda");
            //AtualizarEnderecoDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", "Rua 10 de Junho, 7");
            //AtualizarCodPostalDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", "6300265");
            //AtualizarLocalidadeDeClienteComNomeComecadoEComNif(ctx, "Ric", "111111114", "Vila Garcia");
            //AtualizarSenhaDeUtilizadorComNomeComecado(ctx, "Ricardo", "123", "202cb962ac59075b964b07152d234b70");

            //EliminarClienteComNomeComecadoEComNif(ctx, "teste", "123456789");
        }

        //------------------------------------------------------------------------------------------------------
        //Funções CRUD do Repositório | Ver Playground do CRUD do RepositorioCliente no Main()
        //Create
        public static void CriarClienteNovo()
        {
            var repo = new RepositorioClienteMemoria();
            var cliente3 = new Cliente
            {
                Nome = "Nome de cliente 3",
                NIF = "111111113",
                DataNascimento = new DateTime(2009, 07, 10),
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Secundária,
                    Distrito = "Portalegre",
                    Endereco = "Rua das Oliveiras, 4",
                    CodigoPostal = "4444222",
                    Localidade = "Vaiamonte"
                }
            };
            repo.CriarObjetoLista(cliente3);
            var listaDeClientes = repo.LerTodos();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }

        public static void CriarClienteNovo2()
        {
            var repo = new RepositorioClienteMemoria();
            var cliente4 = new Cliente
            {
                Nome = "Nome de cliente 4",
                NIF = "111111114",
                DataNascimento = new DateTime(2009, 07, 10),
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Secundária,
                    Distrito = "Portalegre",
                    Endereco = "Rua das Oliveiras, 4",
                    CodigoPostal = "4444222",
                    Localidade = "Vaiamonte"
                }
            };
            repo.CriarObjeto(cliente4);
            var listaDeClientes = repo.LerTodos();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }

        //Read
        public static void ListarClientePorNome(string nome)
        {
            var repo = new RepositorioClienteMemoria();
            var cliente = repo.LerPorNomeLista(nome);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(cliente);
        }

        public static void ListarClientePorNif(string nif)
        {
            var repo = new RepositorioClienteMemoria();
            var cliente = repo.LerPorNifLista(nif);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(cliente);
        }

        public static void ListarClientePorId(Guid id)
        {
            var repo = new RepositorioClienteMemoria();
            var lista = repo.LerTodosLista();
            var idTeste = lista[0].Id;
            var cliente = repo.LerPorId(idTeste);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine(cliente);
        }

        public static void ListarTodosOsClientes()
        {
            var repo = new RepositorioClienteMemoria();
            var listaDeClientes = repo.LerTodosLista();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }

        public static void ListarTodosOsClientes2()
        {
            var repo = new RepositorioClienteMemoria();
            var listaDeClientes = repo.LerTodos();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }

        //Update
        public static void AtualizarNomeDeClienteProcuraPorNome(string nomeAntigo, string nomeNovo)
        {
            var repo = new RepositorioClienteMemoria();
            var cliente = repo.AtualizarNomeProcuraNomeLista(nomeAntigo, nomeNovo);
            if (cliente != null)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(cliente);
            }
        }

        public static void AtualizarNomeDeClienteProcuraPorNif(string nif, string nomeNovo)
        {
            var repo = new RepositorioClienteMemoria();
            var cliente = repo.AtualizarNomeProcuraNIFLista(nif, nomeNovo);
            if (cliente != null)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(cliente);
            }
        }

        public static void AtualizarNifDeClienteProcuraPorNome(string nome, string nifNovo)
        {
            var repo = new RepositorioClienteMemoria();
            var cliente = repo.AtualizarNifProcuraNomeLista(nome, nifNovo);
            if (cliente != null)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(cliente);
            }
        }

        public static void AtualizarNifDeClienteProcuraPorNif(string nifAntigo, string nifNovo)
        {
            var repo = new RepositorioClienteMemoria();
            var cliente = repo.AtualizarNifProcuraNifLista(nifAntigo, nifNovo);
            if (cliente != null)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(cliente);
            }
        }

        //Delete
        public static void EliminarClientePorNif(string nif)
        {
            var repo = new RepositorioClienteMemoria();
            repo.EliminarPorProcuraNifLista(nif);
            var listaDeClientes = repo.LerTodos();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }

        public static void EliminarClientePorNome(string nome)
        {
            var repo = new RepositorioClienteMemoria();
            repo.EliminarPorProcuraNomeLista(nome);
            var listaDeClientes = repo.LerTodos();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }

        public static void EliminarTodosOsClientes()
        {
            var repo = new RepositorioClienteMemoria();
            repo.EliminarTodosLista();
            var listaDeClientes = repo.LerTodos();
            foreach (var item in listaDeClientes)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(item);
            }
        }


        //------------------------------------------------------------------------------------------------------
        //Funções CRUD do acesso à Base de Dados para Clientes | Ver Playground do CRUD do acesso à Base de Dados no Main()

        //Create
        private static void CriarClienteNovo(ConexaoBDContexto ctx)
        {
            var cliente0 = new Cliente
            {
                Nome = "Ana I.F.D. da Costa",
                NIF = "111111113",
                MoradaCliente = new Morada()
                {
                    TipoMorada = TipoMorada.Secundária,
                    Distrito = "Porto",
                    Endereco = "Rua 5 de Outubro, 1, 4.º Esq.",
                    CodigoPostal = "1122333",
                    Localidade = "Bela Vista"
                }
            };
            ctx.Clientes.Add(cliente0);
            ctx.SaveChanges();
            Console.WriteLine("Cliente salvo com sucesso na base de dados.");
        }

        //Read
        private static void ApresentarClienteComMorada(Cliente cli)
        {
            var sb = new StringBuilder();
            sb.AppendLine("--------------------------------------------------------");
            sb.AppendLine("                ID: " + cli.Id);
            sb.AppendLine("              Nome: " + cli.Nome);
            sb.AppendLine("               NIF: " + cli.NIF);
            sb.AppendLine("Data de Nascimento: " + cli.DataNascimento);
            sb.AppendLine("             Idade: " + cli.Idade);
            sb.AppendLine("             Ativo: " + cli.Ativo);
            sb.AppendLine("   Data de Criação: " + cli.DataCriacao);
            sb.AppendLine("  Última Alteração: " + cli.DataAlteracao);
            sb.AppendLine("    Tipo de Morada: " + cli.MoradaCliente.TipoMorada);
            sb.AppendLine("          Distrito: " + cli.MoradaCliente.Distrito);
            sb.AppendLine("          Endereço: " + cli.MoradaCliente.Endereco);
            sb.AppendLine("     Código-Postal: " + cli.MoradaCliente.CodigoPostal.Substring(0, 4) + "-" + cli.MoradaCliente.CodigoPostal.Substring(4, 3));
            sb.AppendLine("        Localidade: " + cli.MoradaCliente.Localidade);
            Console.WriteLine(sb.ToString());
        }

        private static void ApresentarClienteSemMorada(Cliente cli)
        {
            var sb = new StringBuilder();
            sb.AppendLine("--------------------------------------------------------");
            sb.AppendLine("                ID: " + cli.Id);
            sb.AppendLine("              Nome: " + cli.Nome);
            sb.AppendLine("               NIF: " + cli.NIF);
            sb.AppendLine("Data de Nascimento: " + cli.DataNascimento);
            sb.AppendLine("             Idade: " + cli.Idade);
            sb.AppendLine("             Ativo: " + cli.Ativo);
            sb.AppendLine("   Data de Criação: " + cli.DataCriacao);
            sb.AppendLine("  Última Alteração: " + cli.DataAlteracao);
            Console.WriteLine(sb.ToString());
        }

        private static void ListarTodosOsClientes(ConexaoBDContexto ctx, bool comMorada)
        {
            var listaClientes = ctx.Clientes.Include("MoradaCliente").OrderBy(x => x.Nome);
            foreach (var item in listaClientes)
            {
                if (comMorada)
                {
                    ApresentarClienteComMorada(item);
                }
                else
                {
                    ApresentarClienteSemMorada(item);
                }
            }
        }

        private static void ListarClientesAtivos(ConexaoBDContexto ctx, bool comMorada)
        {
            var listaClientes = ctx.Clientes.Include("MoradaCliente").Where(c => c.Ativo == true).OrderBy(x => x.Nome);
            foreach (var item in listaClientes)
            {
                if (comMorada)
                {
                    ApresentarClienteComMorada(item);
                }
                else
                {
                    ApresentarClienteSemMorada(item);
                }
            }
        }

        private static void ListarClientesNaoAtivos(ConexaoBDContexto ctx, bool comMorada)
        {
            var listaClientes = ctx.Clientes.Include("MoradaCliente").Where(c => c.Ativo == false).OrderBy(x => x.Nome);
            foreach (var item in listaClientes)
            {
                if (comMorada)
                {
                    ApresentarClienteComMorada(item);
                }
                else
                {
                    ApresentarClienteSemMorada(item);
                }
            }
        }

        private static void ListarClientesComNIF(ConexaoBDContexto ctx, string nif, bool comMorada)
        {
            var listaClientes = ctx.Clientes.Include("MoradaCliente").Where(c => c.NIF == nif).OrderBy(x => x.Nome);
            foreach (var item in listaClientes)
            {
                if (comMorada)
                {
                    ApresentarClienteComMorada(item);
                }
                else
                {
                    ApresentarClienteSemMorada(item);
                }
            }
        }

        private static void ListarClientesComNomeComecado(ConexaoBDContexto ctx, string inicio, bool comMorada)
        {
            var listaClientes = ctx.Clientes.Include("MoradaCliente").Where(c => c.Nome.StartsWith(inicio)).OrderBy(x => x.Nome);
            foreach (var item in listaClientes)
            {
                if (comMorada)
                {
                    ApresentarClienteComMorada(item);
                }
                else
                {
                    ApresentarClienteSemMorada(item);
                }
            }
        }

        private static void ListarClientesComNomeQueContem(ConexaoBDContexto ctx, string conteudo, bool comMorada)
        {
            var listaClientes = ctx.Clientes.Include("MoradaCliente").Where(c => c.Nome.Contains(conteudo)).OrderBy(x => x.Nome);
            foreach (var item in listaClientes)
            {
                if (comMorada)
                {
                    ApresentarClienteComMorada(item);
                }
                else
                {
                    ApresentarClienteSemMorada(item);
                }
            }
        }

        //Update
        private static void AtualizarEstadoDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif, bool novoEstado)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                cliente.Ativo = novoEstado;
                cliente.DataAlteracao = DateTime.Now;
                ctx.SaveChanges();
                Console.WriteLine($"Estado do cliente alterado para {novoEstado} com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarNomeDeClienteComNome(ConexaoBDContexto ctx, string nomeAntigo, string nomeNovo)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.Nome == nomeAntigo);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.Nome = nomeNovo;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Nome do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            } 
        }

        private static void AtualizarNomeDeClienteComNIF(ConexaoBDContexto ctx, string nif, string nomeNovo)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.Nome = nomeNovo;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Nome do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
}

        private static void AtualizarNomeDeClienteComNomeComecado(ConexaoBDContexto ctx, string inicioNome, string nomeNovo)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.Nome.StartsWith(inicioNome));
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.Nome = nomeNovo;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Nome do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarNifDeClienteComNomeComecado(ConexaoBDContexto ctx, string inicioNome, string nifNovo)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.Nome.StartsWith(inicioNome));
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    if (nifNovo.Length == 9 && nifNovo.All(char.IsDigit))
                    {
                        cliente.NIF = nifNovo;
                        cliente.DataAlteracao = DateTime.Now;
                        ctx.SaveChanges();
                        Console.WriteLine("NIF do cliente alterado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("O NIF deve conter exatamente 9 carateres numéricos.");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarNomeDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNomeAntigo, string nif, string nomeNovo)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.Nome.StartsWith(inicioNomeAntigo) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.Nome = nomeNovo;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Nome do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarNifDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nifAntigo, string nifNovo)
        {
            var cliente = ctx.Clientes.FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nifAntigo);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    if (nifNovo.Length == 9 && nifNovo.All(char.IsDigit))
                    {
                        cliente.NIF = nifNovo;
                        cliente.DataAlteracao = DateTime.Now;
                        ctx.SaveChanges();
                        Console.WriteLine("NIF do cliente alterado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("O NIF deve conter exatamente 9 carateres numéricos.");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarTipoMoradaDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif, TipoMorada novoTipoMorada)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.MoradaCliente.TipoMorada = novoTipoMorada;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Tipo de Morada do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarDistritoDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif, string novoDistrito)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.MoradaCliente.Distrito = novoDistrito;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Distrito do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarEnderecoDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif, string novoEndereco)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.MoradaCliente.Endereco = novoEndereco;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Endereço do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarCodPostalDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif, string novoCodPostal)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    if (novoCodPostal.Length == 7 && novoCodPostal.All(char.IsDigit))
                    {
                        cliente.MoradaCliente.CodigoPostal = novoCodPostal;
                        cliente.DataAlteracao = DateTime.Now;
                        ctx.SaveChanges();
                        Console.WriteLine("Código Postal do cliente alterado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("O Código Postal deve conter exatamente 7 carateres numéricos.");
                    }
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        private static void AtualizarLocalidadeDeClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif, string novaLocalidade)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    cliente.MoradaCliente.Localidade = novaLocalidade;
                    cliente.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Tipo de Morada do cliente alterado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        //Delete
        private static void EliminarClienteComNomeComecadoEComNif(ConexaoBDContexto ctx, string inicioNome, string nif)
        {
            var cliente = ctx.Clientes.Include("MoradaCliente").FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.NIF == nif);
            if (cliente != null)
            {
                if (cliente.Ativo)
                {
                    var idMorada = cliente.MoradaCliente.Id;
                    var morada = ctx.Moradas.FirstOrDefault(n => n.Id == idMorada);
                    ctx.Clientes.Remove(cliente);
                    ctx.Moradas.Remove(morada);
                    ctx.SaveChanges();
                    Console.WriteLine($"Cliente e Morada removidos da base de dados com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não Ativo - não é possível proceder à eliminação.");
                }
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }




        //------------------------------------------------------------------------------------------------------
        //Funções CRUD do acesso à Base de Dados para Utilizadores | Ver Playground do CRUD do acesso à Base de Dados no Main()

        //Create
        private static void CriarUtilizadorNovo(ConexaoBDContexto ctx)
        {
            var utilizador0 = new Utilizador
            {
                Nome = "Ricardo A.G. dos Reis",
                EmailLogin = "ricardo.reis@intranet.rr",
                PasswordLogin = "123"
            };
            ctx.Utilizadores.Add(utilizador0);
            ctx.SaveChanges();
            Console.WriteLine("Utilizador salvo com sucesso na base de dados.");
        }

        //Read
        private static void ApresentarUtilizador(Utilizador uti)
        {
            var sb = new StringBuilder();
            sb.AppendLine("--------------------------------------------------------");
            sb.AppendLine("                ID: " + uti.Id);
            sb.AppendLine("              Nome: " + uti.Nome);
            sb.AppendLine("   E-mail de Login: " + uti.EmailLogin);
            sb.AppendLine("    Senha de Login: " + uti.PasswordLogin);
            sb.AppendLine("             Ativo: " + uti.Ativo);
            sb.AppendLine("   Data de Criação: " + uti.DataCriacao);
            sb.AppendLine("  Última Alteração: " + uti.DataAlteracao);
            Console.WriteLine(sb.ToString());
        }

        private static void ListarTodosOsUtilizadores(ConexaoBDContexto ctx)
        {
            var listaUtilizadores = ctx.Utilizadores.OrderBy(x => x.Nome);
            foreach (var item in listaUtilizadores)
            {
                ApresentarUtilizador(item);
            }
        }

        //Update
        private static void AtualizarSenhaDeUtilizadorComNomeComecado(ConexaoBDContexto ctx, string inicioNome, string senhaAntiga, string senhaNova)
        {
            var utilizador = ctx.Utilizadores.FirstOrDefault(x => x.Nome.StartsWith(inicioNome) && x.PasswordLogin == senhaAntiga);
            if (utilizador != null)
            {
                if (utilizador.Ativo)
                {
                    utilizador.PasswordLogin = senhaNova;
                    utilizador.DataAlteracao = DateTime.Now;
                    ctx.SaveChanges();
                    Console.WriteLine("Senha do utilizador alterada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Utilizador não Ativo - não é possível proceder a atualizações.");
                }
            }
            else
            {
                Console.WriteLine("Utilizador não encontrado ou senha em vigor errada.");
            }
        }

        //Delete
        private static void EliminarUtilizadorComNomeComecado(ConexaoBDContexto ctx, string inicioNome)
        {
            var utilizador = ctx.Utilizadores.FirstOrDefault(x => x.Nome.StartsWith(inicioNome));
            if (utilizador != null)
            {
                if (utilizador.Ativo)
                {
                    ctx.Utilizadores.Remove(utilizador);
                    ctx.SaveChanges();
                    Console.WriteLine($"Utilizador removido da base de dados com sucesso.");
                }
                else
                {
                    Console.WriteLine("Utilizador não Ativo - não é possível proceder à eliminação.");
                }
            }
            else
            {
                Console.WriteLine("Utilizador não encontrado.");
            }
        }

    }
}
