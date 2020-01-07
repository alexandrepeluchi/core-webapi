using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIIntroducao.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIIntroducao
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
            services.AddDbContext<ApplicationDbContext>( options => 
                options.UseInMemoryDatabase("productsDB") 
            );

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Se o context Categories estiver vazio, acontece uma adição de valores
            if(!context.Categories.Any())
            {
                context.Categories.AddRange(new List<Categories>()
                {
                    new Categories(){ Nome = "Alimentos" },      
                    new Categories(){ Nome = "Bebidas" },
                    new Categories(){ Nome = "Limpeza" }   
                });
            }

            // SaveChanges para passar as informações para o Banco de Dados
            context.SaveChanges();
        }
    }
}
