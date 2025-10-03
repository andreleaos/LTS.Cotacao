using Dapper;
using LTS.Cotacao.Application.Adapters.Services;
using LTS.Cotacao.Domain.Ports.Repositories;
using LTS.Cotacao.Domain.Ports.Services;
using LTS.Cotacao.Infrastructure.Adapters.Repositories;
using LTS.Cotacao.Infrastructure.Data.Context;
using LTS.Cotacao.Infrastructure.Data.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LTS.Cotacao.IoC
{
    public static class Startup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDatabase(services, configuration);
            ConfigureDependencies(services);
            ConfigureCors(services);
            ConfigureSwagger(services, configuration);
            RegisterDapperTypeHandler();
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string name = "DefaultConnection";

            // tenta via GetConnectionString e cai para a chave plain, se necessário
            string connStr = configuration.GetConnectionString(name) ?? configuration[$"ConnectionStrings:{name}"]
                 ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") // extra, caso use esse formato
                 ?? Environment.GetEnvironmentVariable("IT_MYSQL_CONNECTION"); ;

            // fallback explícito para env-var (ex.: E2E injeta aqui)
            connStr ??= Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

            if (string.IsNullOrWhiteSpace(connStr))
            {
                throw new InvalidOperationException(
                    $"Connection string '{name}' não configurada. " +
                    "Defina ConnectionStrings:DefaultConnection (appsettings, env ou WebApplicationFactory nos testes).");
            }

            // dica útil em DEV/E2E: exibir host:porta (sem senha)
            try
            {
                var builder = new MySqlConnector.MySqlConnectionStringBuilder(connStr);
                Console.WriteLine($"[DB] Using {builder.Server}:{builder.Port} / {builder.Database}");
            }
            catch { /* ignore em prod */ }

            services.AddSingleton(new DapperContext(connStr));
        }

        private static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IStockQuoteRepository, StockQuoteRepository>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IStockQuoteService, StockQuoteService>();
        }

        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("default", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        private static void ConfigureSwagger(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Cotação de Ações",
                    Version = "v1"
                });
            });
        }

        public static void ConfigureSwagger(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }
        }

        public static void SetCorsConfig(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors("default");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void RegisterDapperTypeHandler()
        {
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
            SqlMapper.AddTypeHandler(new NullableDateOnlyTypeHandler());
        }
    }
}
