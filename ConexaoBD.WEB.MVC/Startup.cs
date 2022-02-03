using ConexaoBD.DAL.Model;
using ConexaoBD.DAL.Repositorios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
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
            var connectionString = Configuration.GetConnectionString("MinhaConexaoDevelopment");
            services.AddDbContext<ConexaoBDContexto>(options => options.UseSqlServer(connectionString));

            //https://www.youtube.com/watch?v=egITMrwMOPU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=65
            //https://www.youtube.com/watch?v=kC9qrUcy2Js&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=68&t=2s
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireDigit = true; //default
                options.Password.RequireLowercase = true; //default
                options.Password.RequireNonAlphanumeric = true; //default
                options.Password.RequireUppercase = true; //desault
                options.Password.RequireLowercase = true; //default
            }).AddEntityFrameworkStores<ConexaoBDContexto>();

            //https://www.youtube.com/watch?v=BWa7Mu-oMHk&list=PLH-n_HU-47l5hp4VPKpUi-VQQlcnRg15h&index=11&t=185s
            //ASP.NET Core 5.0 - Authentication/Authorization - .Net Engineering Forum 2021-01-26 -> 13:20
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/login";
                });

            //Vídeo 71 - 7:30
            services.AddMvc(options => {
                var politicaDeAutorizacao = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(politicaDeAutorizacao));
            }).AddXmlSerializerFormatters();

            //Vídeo 49 - 12:00
            //services.AddTransient<IRepositorio<Cliente>, RepositorioClienteBD>();
            services.AddScoped<IRepositorio<Cliente>, RepositorioClienteBD>();

            services.AddControllersWithViews();
            //services.AddLogging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConexaoBDContexto conexaoBDContexto)
        {
            conexaoBDContexto.Database.EnsureCreated();
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

            //https://www.youtube.com/watch?v=BWa7Mu-oMHk&list=PLH-n_HU-47l5hp4VPKpUi-VQQlcnRg15h&index=11&t=185s
            //ASP.NET Core 5.0 - Authentication/Authorization - .Net Engineering Forum 2021-01-26 -> 28:05
            //https://www.youtube.com/watch?v=egITMrwMOPU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=65
            app.UseAuthentication();

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
