using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using AssetManagement.Api.Utility;
using AssetManagement.Api.Utility.Middleware;
using AssetManagement.Api.Utility.ModelValidateion;

namespace AssetManagement.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; set; }

        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices (IServiceCollection services)
        {
            services.AddMvc (options =>
            {
                options.MaxModelValidationErrors = 50;
                options.Filters.Add<ModelValidationAttribute> ();
            }).SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen (c =>
            {
                c.SwaggerDoc (
                    name: "v1",
                    info : new Info
                    {
                        Title = "Asset Management API",
                            Version = "1.0.0",
                            Description = "An asset management system",
                            TermsOfService = "None",
                            Contact = new Contact
                            {
                                Name = "Reggie",
                                    Url = "https://www.linkedin.com/in/reggie-chen-b49280aa/"
                            }
                    }
                );
                var filePath = Path.Combine (PlatformServices.Default.Application.ApplicationBasePath, "Api.xml");
                c.IncludeXmlComments (filePath);
            });

            services.AddHttpClient();

            var builder = new ContainerBuilder();

            var domain = Assembly.Load("AssetManagement.Domain");
            builder.RegisterAssemblyTypes(domain).AsImplementedInterfaces();

            var repository = Assembly.Load("AssetManagement.Repository");
            builder.RegisterAssemblyTypes(repository).AsImplementedInterfaces();

            builder.RegisterType<ModelValidationAttribute>();
            builder.RegisterType<GUIDVerifyAndRecreate>();

            builder.Populate(services);

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.ConfigureGlobalExceptionMiddleware ();
            app.ConfigureSetupMiddleware ();

            app.UseSwagger ();
            app.UseSwaggerUI (c =>
            {
                c.SwaggerEndpoint (
                    "/swagger/v1/swagger.json",
                    "Asset Management API"
                );
            });

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}