using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using Movilet.Services;



namespace Movilet
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        readonly string PolizaCORSMovilet = "_polizaCORSSISCAR";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      //  public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {

                options.AddPolicy(name: PolizaCORSMovilet,//es una autorizacion con esa poliza
                                 builder =>
                                 {
                                     builder.WithOrigins("http://localhost:8080")
                                                                                    .AllowAnyMethod()
                                                                                    .AllowAnyHeader();
                                 });
            });
            services.AddControllers();
            services.Configure<MoviletDatabaseSettings>(
                Configuration.GetSection(nameof(MoviletDatabaseSettings)));
            services.AddCors();
            services.AddSingleton<IMoviletDatabaseSettings>(sp =>
               sp.GetRequiredService<IOptions<MoviletDatabaseSettings>>().Value);
                services.AddScoped<UsuarioService>();
                services.AddScoped<DocumentoService>();
                services.AddScoped<PacienteService>();
                services.AddScoped<pedidoService>();




            // Se encarga de registrar el generador del swagger
            services.AddSwaggerGen(g =>
            {
                g.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "versi�n 1.0",
                    Title = "Movilet API",
                    Description = "Aplicaci�n que contiene la descripci�n y uso de las APIS de Movilet"
                });

                g.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorizaci�n para la entradas a las apis que generan la cabecera",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                g.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {  new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                   }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseRouting();

            app.UseCors(PolizaCORSMovilet);

            //Habilita el uso del swagger
            app.UseSwagger();

            //Habilita el uso de la interfaz del swagger
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Movilet API V1.0");
            });


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
