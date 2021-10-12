using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using IEH_Dashboard.Common.StaticConstants;
using IEH_Dashboard.Implementations;
using IEH_Dashboard.Infrastructure.DataAccess;
using IEH_Dashboard.Model;
using IEH_Dashboard.Repository.Implementations;
using IEH_Dashboard.Repository.Interfaces;
using IEH_Dashboard.Repository.UnitOfWorkAndBaseRepo;
using IEH_Dashboard.Services.Interfaces;
using IEH_Dashborad.Helpers;
using IEH_Shared.StaticConstants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IEH_Dashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ReadConfigSettings();
           // ReadConfigMessages();
            services.AddSingleton(Configuration);

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<IEHDbContext>(options => options.UseSqlServer(Constants.DbConn));

            //services.AddScoped<LogApiFilter>();
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                   .AddIdentityServerAuthentication(options =>
                   {
                       options.Authority = SharedConstants.Authority;
                       options.ApiName = SharedConstants.APIName;
                       // options.Authority = "https://localhost:44355";
                       //options.Authority = "http://localhost:62726";
                       // options.ApiName = "app.api.weather";
                   });



            services.AddControllers();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSwaggerDocumentation();

            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IDashboardRepository, DashboardRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<HttpClient, HttpClient>();

           // services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var ApplicationClientUrl = "http://localhost:4200/";
            //app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            {
               // ApplicationClientUrl = Configuration["ApplicationSettings:Client_URL"].ToString();
                app.UseExceptionHandler("/Error");
            }
            app.UseSwaggerDocumentation();
            app.UseCors(builder => builder
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// The ReadConfigSettings
        /// </summary>
        private void ReadConfigSettings()
        {
            Constants.DbConn = Configuration["App:DbConn"];
            SharedConstants.Authority = Configuration["Authentication:Authority"];
            SharedConstants.APIName = Configuration["Authentication:APIName"];

            Constants.AzureDbConn = Configuration["UploadDocument:DbConn"];
            Constants.FolderName = Configuration["UploadDocument:FolderName"];
            Constants.ImagePath = Configuration["UploadDocument:ImagePath"];

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
