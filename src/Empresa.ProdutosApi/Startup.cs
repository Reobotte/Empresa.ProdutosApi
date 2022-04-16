using Empresa.ProdutosApi.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;

namespace Empresa.ProdutosApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                // Configura saída do JSon
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                    opt.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                    opt.SerializerSettings.DateFormatString = "dd/MM/yyyy";
                });

            // Versioning API
            services.AddApiVersioning(opt => {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            });

            #region Swegger

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Produtos API",
                    Description = "API com arquitetura em DDD",
                    // URL para os termos de serviço da API    
                    // TermsOfService = new Uri("http://"), 
                    // Informações do Contato da API
                    Contact = new OpenApiContact
                    {
                        Name = "Natael Corrêa",
                        Email = "reobotte@hotmail.com",
                        Url = new Uri("https://www.linkedin.com/in/natael-corr%C3%AAa-32138417b/")
                    },
                    // Informações da Licença para API
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de uso da API",
                        Url = new Uri("https://www.shutterstock.com/pt/license")
                    }
                });
            });

            #endregion Swegger

            services.AddContextDependency(Configuration);
            services.AddDependency();
            services.AddOthersDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region Swegger

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.RoutePrefix = string.Empty;
                opt.SwaggerEndpoint("swagger/v1/swagger.json", "Produtos API");
            });

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("DefaultApi", "api/{controller=vlues}/v1/{id?}");
            });
        }
    }
}
