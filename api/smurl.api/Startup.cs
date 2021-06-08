using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using smurl.data;
using smurl.data.Interfaces;
using smurl.data.Repositories;
using smurl.services.Interfaces;
using smurl.services.Services;
using System;

namespace smurl.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors(options =>
            // {
            //     options.AddDefaultPolicy(builder =>
            //     {
            //         builder
            //             .AllowAnyHeader()
            //             .AllowAnyMethod()
            //             .WithOrigins(Configuration["Cors:Origins"]);
            //     });
            // });

            services.AddControllers();

            services.AddSingleton(new DatabaseConfiguration(Configuration["DatabaseConnections:smurl"]));
            services.AddSingleton<IContext, Context>();

            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IClickRepository, ClickRepository>();

            services.AddScoped<ILinkService, LinkService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IContext>().TestDatabaseConnection();
        }
    }
}