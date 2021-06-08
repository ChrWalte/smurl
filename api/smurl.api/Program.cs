using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace smurl.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostContext, configuration) =>
                    {
                        configuration.AddJsonFile("appsettings.json", optional: false);
                        // var environment = hostContext.HostingEnvironment.EnvironmentName.ToLowerInvariant();
                        // configuration.AddJsonFile($"appsettings.{environment}.json", optional: false);
                    });

                    webBuilder.UseUrls("http://*:5050"); //, "https://*:5051");
                    webBuilder.UseStartup<Startup>();
                });
    }
}