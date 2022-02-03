//https://www.youtube.com/watch?v=egITMrwMOPU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=65
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConexaoBD.DAL.Model
{
    public class ConexaoBDContexto : IdentityDbContext
    {
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupoDeUtilizadores> GrupoDeUtilizadores { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        public ConexaoBDContexto(DbContextOptions<ConexaoBDContexto> options) : base(options) { }


        
    }
}
