using Microsoft.AspNetCore.Mvc;
using Opah.Consolidado.Application.Interfaces;
using Opah.Consolidado.Application.Services;
using CorrelationId.DependencyInjection;
using CorrelationId;
using CorrelationId.Abstractions;
using Opah.Lib.MicrosservicoBase.Exception;
using Opah.Lib.Logger;
using Opah.Lib.HttpBase.Exception;
using Opah.Consolidado.Infra.MongoDB.Repositories;

namespace Opah.Consolidado.API
{
    public class Program
    {
        #region Public Methods

        public static IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            string environment;
            string path;

            string serviceDescription;
            string serviceName;
            string serviceVersion;

            serviceName = configuration["SERVICE_NAME"];
            if (string.IsNullOrWhiteSpace(serviceName))
            {
                throw new OpahException("SERVICE_NAME não especificado");
            }

            serviceDescription = configuration["SERVICE_DESCRIPTION"];
            if (string.IsNullOrWhiteSpace(serviceDescription))
            {
                throw new OpahException("SERVICE_DESCRIPTION não especificado");
            }

            serviceVersion = configuration["SERVICE_VERSION"];
            if (string.IsNullOrWhiteSpace(serviceVersion))
            {
                throw new OpahException("SERVICE_VERSION não especificado");
            }

            environment = configuration["ASPNETCORE_ENVIRONMENT"];
            if (string.IsNullOrWhiteSpace(environment))
            {
                throw new OpahException("ENVIRONMENT não especificado");
            }

            if (string.IsNullOrWhiteSpace(configuration["Opah.Consolidado-MaxMemory"]))
            {
                throw new OpahException("MaxMemory não especificado");
            }

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddSingleton<IInfoService, InfoService>();

            //Configuraçao para os logs

            path = configuration["log-path"];
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new OpahException("caminho do log não especificado");
            }

            builder.Services.AddHttpClient("internal-api-request").AddHeaderPropagation();
            builder.Services.AddHeaderPropagation(o =>
            {
                o.Headers.Add("x-correlation-id");
            });

            builder.Services.AddDefaultCorrelationId(options =>
            {
                options.AddToLoggingScope = true;
                options.EnforceHeader = false;
                options.IgnoreRequestHeader = false;
                options.IncludeInResponse = true;
                options.RequestHeader = "x-correlation-id";
                options.ResponseHeader = "x-correlation-id";
                options.UpdateTraceIdentifier = false;
            });

            builder.Services.AddScoped<IOpahLogger, OpahLogger>(provider =>
                new OpahLogger(provider.GetService<ICorrelationContextAccessor>(), configuration));

            if (string.IsNullOrWhiteSpace(configuration["mongo-connection"]))
            {
                throw new OpahException("Mongo connection não foi especificado");
            }

            if (string.IsNullOrWhiteSpace(configuration["mongo-database"]))
            {
                throw new OpahException("Mongo database não foi especificado");
            }

            builder.Services.AddScoped<IConsolidadoAppService, ConsolidadoAppService>();
            builder.Services.AddScoped<IConsolidadoRepository, ConsolidadoMongoRepository>();

            builder.Services.AddControllers(
            options =>
            {
                options.Filters.Add<HandleOpahException>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if (environment.ToLower() == "development")
            {
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                });
            }

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCorrelationId();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        #endregion Public Methods
    }
}