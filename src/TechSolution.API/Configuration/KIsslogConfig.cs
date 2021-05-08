using Microsoft.Extensions.DependencyInjection;
using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using System.Text;
using System;
using System.Diagnostics;
using TechSolution.API.Extensions;

namespace TechSolution.API.Configuration
{
    public static class KisslogConfig
    {
        private static KisslogSettings KissLogSettings {get; set;}

        public static IServiceCollection AddKisslogConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILogger>((context) =>
            {
                return Logger.Factory.Get();
            });

            services.AddLogging(logging =>
            {
                logging.AddKissLog();
            });

            var kisslogSettings = configuration.GetSection("KisslogSettings");
            services.Configure<KisslogSettings>(kisslogSettings);

            KissLogSettings = kisslogSettings.Get<KisslogSettings>();

            return services;
        }

        public static IApplicationBuilder UseKisslogConfig(this IApplicationBuilder app) 
        {   
            app.UseKissLogMiddleware(options => { ConfigureKissLog(options); });

            return app;
        }

        static void ConfigureKissLog(IOptionsBuilder options)
        {
            // optional KissLog configuration
            options.Options.AppendExceptionDetails((Exception ex) =>
            {
                StringBuilder sb = new StringBuilder();
 
                if (ex is System.NullReferenceException nullRefException)
                {
                    sb.AppendLine("Important: check for null references");
                }
 
                return sb.ToString();
            });
 
            // KissLog internal logs
            options.InternalLog = (message) =>
            {
                Debug.WriteLine(message);
            };
 
            // register logs output
            RegisterKissLogListeners(options);
        }

        private static void RegisterKissLogListeners(IOptionsBuilder options)
        {
            // register KissLog.net cloud listener
            options.Listeners.Add(new RequestLogsApiListener(new Application(KissLogSettings.OrganizationId, KissLogSettings.ApplicationId)){
                ApiUrl = KissLogSettings.ApiUrl
            });
        }
    }
}
