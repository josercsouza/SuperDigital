using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Dominio.Servicos.Implementacao;
using SuperDigital.Infraestrutura.Repositorios;

namespace SuperDigital.Aplicacao
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
            services.AddControllers();

            services.AddSingleton<IServicoDeLancamento, ServicoDeLancamento>();
            services.AddSingleton<IServicoDeContaCorrente, ServicoDeContaCorrente>();

            services.AddSingleton<IRepositorioDeLancamento, RepositorioDeLancamento>();
            services.AddSingleton<IRepositorioDeContaCorrente, RepositorioDeContaCorrente>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
        }
    }
}