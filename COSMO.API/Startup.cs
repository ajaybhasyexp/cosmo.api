﻿using COSMO.API.Resources;
using COSMO.Business;
using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Data.Repositories;
using COSMO.Models.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Globalization;
using System.Text;

namespace COSMO.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IBatchRepository, BatchRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRespository>();
            services.AddTransient<IBatchAssignmentRepository, BatchAssignmentRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IBatchService, BatchService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IBatchAssignmentService, BatchAssignmentService>();
            services.AddTransient<ICommonResource, CommonResource>();

            services.AddLocalization(o => o.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("en-US") };
                options.DefaultRequestCulture = new RequestCulture("en-US", "en-US");

                // You must explicitly state which cultures your application supports.
                // These are the cultures the app supports for formatting 
                // numbers, dates, etc.

                options.SupportedCultures = supportedCultures;

                // These are the cultures the app supports for UI strings, 
                // i.e. we have localized resources for.

                options.SupportedUICultures = supportedCultures;
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseMvc();
            // global cors policy
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.Run(context => {
            //    context.Response.Redirect("swagger/ui");
            //    return Task.CompletedTask;
            //});

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
