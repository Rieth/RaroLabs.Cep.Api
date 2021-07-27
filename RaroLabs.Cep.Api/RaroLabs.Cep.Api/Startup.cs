using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RaroLabs.Cep.Api.Extensions;
using RaroLabs.Cep.Domain.Services;
using RaroLabs.Cep.Infrastructure.Integrations.ViaCep;
using System;
using System.IO;
using System.Reflection;

namespace RaroLabs.Cep.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IEnderecoService, ViaCepService>();
            services.AddControllers();

            services.ConfigureAutoMapper();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RaroLabs Endereco API",
                    Description = "RaroLabs Endereco API",
                    Contact = new OpenApiContact() { Name = "Raro Labs", Email = "rarolabs@email.com.br" },
                    Version = "1.0.0"
                });

                setup.IncludeXmlComments(Path.Combine(
                   AppContext.BaseDirectory,
                   $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RaroLabs.Cep.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
