using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Centrum_Historii_Zajezdnia_WebAPI
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
            //var server = Configuration["DBServer"] ?? "DESKTOP-U4VRK31";
            //var port = Configuration["DBPort"] ?? "44340";
            //var user = Configuration["DbUser"] ?? "sa";
            //var password = Configuration["DBPassword"] ?? "arek";
            //var database = Configuration["Database"] ?? "Monitoring";

            // services.AddDbContext<MonitoringContext>(options => options.UseSqlServer(
            // $"Server={server}, {port}; Initial Catalog={database}; User ID={user}; Password={password}"  ));

            var connection = @"Server=DESKTOP-U4VRK31;Database=Monitoring;Trusted_Connection=True;";
            services.AddDbContext<MonitoringContext>(options => options.UseSqlServer(connection));
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IMeasurementService, MeasurementService>();
            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://localhost:3000"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           // app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowMyOrigin");

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