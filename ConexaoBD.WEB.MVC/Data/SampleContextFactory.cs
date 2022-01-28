using ConexaoBD.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.MVC.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ConexaoBDContexto>
    {
        public ConexaoBDContexto CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<ConexaoBDContexto>();
            var connectionString = configuration.GetConnectionString("MinhaConexaoDevelopment");

            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly("ConexaoBD.DAL"));
            //builder.UseNpgsql(connectionString);

            return new ConexaoBDContexto(builder.Options);
        }

        //https://www.youtube.com/watch?v=XiUL_vNIMxI
    }
}
