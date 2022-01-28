using ConexaoBD.DAL.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConexaoBD.WEB.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = $@"Server=(LocalDB)\MSSQLLocalDB;Database=ConexaoDB;Trusted_Connection=True;";
            //var connectionString = Configuration.GetConnectionString("MinhaConexaoDevelopment");
            //services.AddDbContext<ConexaoBDContexto>(options => options.UseSqlServer(connectionString));

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //, ConexaoBDContexto conexaoBDContexto
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //conexaoBDContexto.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                //conexaoBDContexto.Database.EnsureDeleted(); //Cuidado, isto apaga!
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
