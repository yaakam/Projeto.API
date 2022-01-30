using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Projeto.API.Configuracoes;
using Projeto.Dominio.Extensoes;
using System;
using System.IO;
using System.Text.Json;

namespace Projeto.API
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
            services.AddControllers().AddNewtonsoftJson(F => F.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddTratamentoGlobalDeExececao();
            ConfigurarSwagger(services);
            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            services.AddMvc().AddNewtonsoftJson(F => { F.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
            ConstrutorDeConexao.Construir();
            ConstrutorDeInjecoes.Construir();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseTratamentoGlobalDeExececao();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(F => F.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto"));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(f => f.AllowAnyOrigin());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigurarSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(F =>
            {
                F.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API - Projeto",
                        Version = "v1",
                        Contact =
                        new OpenApiContact
                        {
                            Email = "everaldocardosodearaujo@gmail.com",
                            Name = "Everaldo Cardoso de Araújo",
                        },
                        Description = "API - Projeto",
                    });
                F.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{System.Reflection.Assembly.GetEntryAssembly().GetName().Name}.xml"));
            });
        }
    }
}
