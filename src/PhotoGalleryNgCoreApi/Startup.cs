using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using PhotoGalleryNgCoreApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories.Abstract;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories;
using PhotoGalleryNgCoreApi.Infrastructure.Services.Abstract;
using PhotoGalleryNgCoreApi.Infrastructure.Services;
using System.Security.Claims;
using Newtonsoft.Json.Serialization;
using PhotoGalleryNgCoreApi.Infrastructure.Mappings;
using System.IO;

namespace PhotoGalleryNgCoreApi
{
    public class Startup
    {
        private static string _applicationPath = string.Empty;
        private static string _contentRootPath = string.Empty;

        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            _contentRootPath = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                            .SetBasePath(_contentRootPath)
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            bool useInMemoryProvider = bool.Parse(Configuration["Data:PhotoGalleryConnection:InMemoryProvider"]);

            services.AddDbContext<PhotoGalleryContext>(options =>
            {
                switch (useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase();
                        break;
                    default:
                        options.UseSqlServer(sqlConnectionString);
                        break;
                }
            });

            // Repositories
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ILoggingRepository, LoggingRepository>();

            // Services
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IEncryptionService, EncryptionService>();

            services.AddAuthentication();

            // Policies
            services.AddAuthorization(options =>
            {
                // inline policies
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });
            });

            // Add MVC services to the services container
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    var resolver = opt.SerializerSettings.ContractResolver;
                    if (resolver != null)
                    {
                        var res = resolver as DefaultContractResolver;
                        res.NamingStrategy = null;
                    }
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // this will serve up wwwroot
            app.UseStaticFiles();

            AutoMapperConfiguration.Configure();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            // Custom Authentication middleware
            // app.UserMiddleware<AuthMiddleware>();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(app.ApplicationServices, _applicationPath);
            //loggerFactory.AddConsole();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        // Entry point for the application.
        //public static void Main(string[] args)
        //{
        //    var host = new WebHostBuilder()
        //                .UseKestrel()
        //                .UseContentRoot(Directory.GetCurrentDirectory())
        //                .UseIISIntegration()
        //                .UseStartup<Startup>()
        //                .Build();
        //    host.Run();
        //}
    }
}
