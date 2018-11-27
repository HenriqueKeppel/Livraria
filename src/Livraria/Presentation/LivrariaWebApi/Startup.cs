﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Application;
using LivrosAdapter;
using Livraria.FavoritosAdapter;
using Livraria.CriticasAdapter;
using Livraria.ReputacoesAdapter;

namespace LivrariaWebApi
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
            services.AddMvc();
            // Register the Swagger generator, defining 1 or more swagger documentos
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "LivrariaApi", Version = "v1" });
            });

            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<ILivroAdapter, LivroAdapter>();
            services.AddScoped<IFavoritoService, FavoritoService>();
            services.AddScoped<IFavoritosAdapter, FavoritoAdapter>();
            services.AddScoped<ICriticaService, CriticaService>();
            services.AddScoped<ICriticasAdapter, CriticaAdapter>();
            services.AddScoped<IReputacaoService, ReputacaoService>();
            services.AddScoped<IReputacoesAdapter, ReputacaoAdapter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LivrariaApi-v1");
            });

            app.UseMvc();
        }
    }
}
