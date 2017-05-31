﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Extensions.Configuration;
using Library.Features.Reservation.DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Library.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Library.Features.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Library.Services;

namespace Library
{
    public class Startup
    {

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Startup>()
                .Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddFeatureFolders();

            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            //Configurando o DBContext
            services
                .AddDbContext<LibraryDbContext>(options =>
                {
                    var connectionStrings = Configuration.GetSection("ConnectionStrings").GetValue<string>("Library");
                
                    options.UseSqlServer(connectionStrings);
                });
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LibraryDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {            
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseIdentity();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //Ciar alguns registros iniciais no banco de dados
            using(var scope = app.ApplicationServices.CreateScope())
                scope.ServiceProvider.GetService<LibraryDbContext>().SeedDatabase();

        }
    }
}
