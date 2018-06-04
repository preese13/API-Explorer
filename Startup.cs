using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using mockAPI.Models;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using FluentEmail.Mailgun;

namespace mockAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<EmployeeContext>(opt => opt.UseInMemoryDatabase("Employee"));
            services.AddDbContext<DeductionContext>(opt => opt.UseInMemoryDatabase("Deduction"));
            services.AddDbContext<IncomingEmployeeContext>(opt => opt.UseInMemoryDatabase("IncomingEmployee"));
            services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("User"));
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.IgnoreObsoleteProperties();
                c.IgnoreObsoleteActions();

                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Employee Navigator",

                });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                    Description = "Authorization reset when navigating to documentation tab"
                });
                
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);

            });

            services.AddTransient<EmployeeInitializer>();
            services.AddTransient<DeductionInitializer>();
            services.AddTransient<IncomingEmployeeInitializer>();
            services.AddTransient<UserIntitializer>();
        }


        public void Configure(IApplicationBuilder app,
                                IHostingEnvironment env,
                                ILoggerFactory loggerFactory,
                                EmployeeInitializer employeeSeeder,
                                DeductionInitializer deductionSeeder,
                                IncomingEmployeeInitializer incomingEmployeeSeeder,
                                UserIntitializer userSeeder)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "api")),
                RequestPath = "/Api",
            });

            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Navigator V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
            });

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();

            employeeSeeder.Seed().Wait();
            deductionSeeder.Seed().Wait();
            incomingEmployeeSeeder.Seed().Wait();
            userSeeder.Seed().Wait();
        }
    }
}
