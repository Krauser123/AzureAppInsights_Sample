/*using System;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AzureAppInsights_Sample
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IMyInterface, MyClass>();

            services.AddControllers();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = Constants.RootPath;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            //Add telemetry using connectionString and other params from appSettings
            ApplicationInsightsServiceOptions applicationInsightsServiceOptions = new ApplicationInsightsServiceOptions()
            {
                ConnectionString = this.Configuration["ApplicationInsights:ConnectionString"],
                EnableAdaptiveSampling = Convert.ToBoolean(Configuration["ApplicationInsights:EnableAdaptiveSampling"])
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            // This sample app serves a Single Page Application
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add(Constants.XFrameOptionsHeaderKey, Constants.XFrameOptionsHeaderValue);
                await next.Invoke();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.) specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Constants.SwaggerEndpoint, Constants.SwaggerEndpointTitle);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Constants.SourcePath;
                spa.Options.StartupTimeout = TimeSpan.FromSeconds(180);
                if (env.EnvironmentName == "Local")
                {
                    spa.UseReactDevelopmentServer(npmScript: Constants.NpmScript);
                }
            });
        }
    }
}*/