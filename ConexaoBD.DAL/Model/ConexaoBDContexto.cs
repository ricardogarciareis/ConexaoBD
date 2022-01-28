using Microsoft.EntityFrameworkCore;

namespace ConexaoBD.DAL.Model
{
    public class ConexaoBDContexto : DbContext
    {
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupoDeUtilizadores> GrupoDeUtilizadores { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        public ConexaoBDContexto(DbContextOptions<ConexaoBDContexto> options) : base(options) { }


        
    }
}
