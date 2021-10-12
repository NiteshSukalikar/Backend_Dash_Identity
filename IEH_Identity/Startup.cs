using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IEH_Dashboard.Common.StaticConstants;
using IEH_Identity.Common;
using IEH_Identity.Data;
using IEH_Identity.IService;
using IEH_Identity.service;
using IEH_Shared.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;

namespace IEH_Identity
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration, IWebHostEnvironment env)
        {
            //Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false, true)
            .AddJsonFile("appsettingsMessages.json", true, true);
            Configuration = configuration;
            Configuration = builder.Build();
        }
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ReadConfigSettings();
           // ReadConfigMessages();
            services.AddSingleton(Configuration);

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            // const string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;database=IEHTemp;trusted_connection=yes;";
            //const string connectionString = @"Data Source=75.126.168.31,7009;database=IntegratedeHealth;trusted_connection=yes;";
            // const string connectionString = @"Data Source=75.126.168.31,7009;database=IntegratedeHealth;Initial Catalog=IntegratedeHealth;User Id=IntegratedeHealth;Password=smaDRT23456y@;MultipleActiveResultSets=True";


            //services
            //.AddControllers()
            //.AddNewtonsoftJson(x => x.SerializerSettings.Converters.Add(new StringEnumConverter())).AddControllersAsServices().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
          .AddTransient<IProfileService, ProfileService>()
          .AddTransient<IAuthRepository, AuthRepository>()
        .AddTransient<IDataService, DataService>();
            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(Constants.DbConn)
                    );

            services.AddIdentityServer()

          .AddDeveloperSigningCredential()
          .AddInMemoryApiResources(Data.ResourceManager.Apis())
          .AddInMemoryClients(Data.ClientManager.Clients())
          .AddConfigurationStore(options =>

           options.ConfigureDbContext = builder => builder.UseSqlServer(Constants.DbConn, options =>
          options.MigrationsAssembly(migrationsAssembly)))
          .AddOperationalStore(options =>
          options.ConfigureDbContext = builder =>
         builder.UseSqlServer(Constants.DbConn, options =>
          options.MigrationsAssembly(migrationsAssembly)));

            services.AddCors(confg =>
               confg.AddPolicy("AllowAll",
                   p => p.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()));
            services.AddControllers();

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});

            services.AddSwaggerDocumentation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIdentityServer();
            InitializeDatabase(app);
            app.UseCors("AllowAll");

            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerDocumentation();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {

                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Data.ClientManager.Clients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Data.ResourceManager.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Data.ResourceManager.Apis())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// The ReadConfigSettings
        /// </summary>
        private void ReadConfigSettings()
        {
            Constants.DbConn = Configuration["App:DbConn"];
        }

        /// <summary>
        /// The ReadConfigMessages
        /// </summary>
        private void ReadConfigMessages()
        {
            //##################################### Shared ####################################################
            //############################ Error Messages ############################################

            IEHMessages.GeneralException = Configuration["Messages:GeneralException"];
            IEHMessages.RecordNotFound = Configuration["Messages:RecordNotFound"];
            IEHMessages.SavedSuccessfully = Configuration["Messages:SavedSuccessfully"];
            IEHMessages.UpdatedSuccessfully = Configuration["Messages:UpdatedSuccessfully"];
            IEHMessages.DeletedSuccessfully = Configuration["Messages:DeletedSuccessfully"];
            IEHMessages.VerificationRequired = Configuration["Messages:VerificationRequired"];
            IEHMessages.RegistrationRequired = Configuration["Messages:RegistrationRequired"];
            IEHMessages.RecordAlreadyExists = Configuration["Messages:RecordAlreadyExists"];
            IEHMessages.DateGreaterThanNowError = Configuration["Messages:DateGreaterThanNowError"];
            IEHMessages.OperationSuccessful = Configuration["Messages:OperationSuccessful"];
            IEHMessages.AccountNotExist = Configuration["Messages:AccountNotExist"];
            IEHMessages.InvalidUser = Configuration["Messages:InvalidUser"];
            IEHMessages.AccountAlreadyExist = Configuration["Messages:AccountAlreadyExist"];
            IEHMessages.InvalidToken = Configuration["Messages:InvalidToken"];
            IEHMessages.EmailAlreadyVerified = Configuration["Messages:EmailAlreadyVerified"];
            IEHMessages.AccountBlocked = Configuration["Messages:AccountBlocked"] + IEHMessages.SupportEmail;
            IEHMessages.EmailAccountExist = Configuration["Messages:EmailAccountExist"];
            IEHMessages.AccessDenied = Configuration["Messages:AccessDenied"];
            IEHMessages.InvalidPassword = Configuration["Messages:InvalidPassword"];
            IEHMessages.ImageUploaded = Configuration["Messages:ImageUploaded"];
            IEHMessages.UnauthorizedUser = Configuration["Messages:UnauthorizedUser"];
            IEHMessages.UserNotFound = Configuration["Messages:UserNotFound"];
            IEHMessages.EmailorPasswordWrong = Configuration["Messages:EmailorPasswordWrong"];
            IEHMessages.RestrictAdminLogin = Configuration["Messages:RestrictAdminLogin"];
            IEHMessages.RestrictReviewerLogin = Configuration["Messages:RestrictReviewerLogin"];
            IEHMessages.LoginSuspendedMessage = Configuration["Messages:LoginSuspendedMessage"];
        }
    }
}
