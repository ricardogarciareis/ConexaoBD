using ConexaoBD.DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ConexaoBD.DAL.Model
{
    public class ConexaoBDContexto : DbContext
    {
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupoDeUtilizadores> GrupoDeUtilizadores { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        //public ConexaoBDContexto(DbContextOptions<ConexaoBDContexto> options) : base(options) { }

        //public ConexaoBDContexto() { }


        //Configuração de conexão à base de dados MS SQLServer - Funciona e é necessário para os Services
        //Também está configurado no Startup para ser utilizado nos Controllers (prefiro esta opção mas ela não funciona para os Services)
        //https://www.learnentityframeworkcore.com/connection-strings
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = $@"Server=(LocalDB)\MSSQLLocalDB;Database=ConexaoDB;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }


        //private readonly IConfiguration _configuration;
        //public ConexaoBDContexto(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MinhaConexaoDevelopment"));
        //}


        //Configuração de conexão à base de dados SQLite
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = $@"Data Source=D:\ConexaoBD_vs00\bd_Sqlite\BD00.db";
        //    options.UseSqlite(connectionString);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    CodificacaoDePassword codificacaoDePassword = new CodificacaoDePassword();
        //    modelBuilder.Entity<GrupoDeUtilizadores>().HasData(
        //        new GrupoDeUtilizadores
        //        {
        //            Id = new int(),
        //            Nome = "Admin",
        //            TipoDeGrupoDeUtilizadores = "Administrador"
        //        },
        //        new Utilizador
        //        {
        //            EmailLogin = "admin@intranet.rr",
        //            PasswordLogin = codificacaoDePassword.ObterHashMD5("123456"),
        //            Ativo = true,
        //            Nome = "Asmin",
        //            GrupoDeUtilizadoresId = 1
        //        });
        //}
    }
}
