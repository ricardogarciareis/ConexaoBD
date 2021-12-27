using ConexaoBD.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ConexaoBD.DAL.Model
{
    public class ConexaoBDContexto : DbContext
    {
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        ////Configuração de conexão à base de dados MS SQLServer
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = $@"Server=(LocalDB)\MSSQLLocalDB;Database=ConexaoDB;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }

        //Configuração de conexão à base de dados SQLite
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = $@"Data Source=D:\ConexaoBD_vs00\bd_Sqlite\BD00.db";
        //    options.UseSqlite(connectionString);
        //}
    }
}
