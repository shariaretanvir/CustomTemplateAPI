using AspNetCoreRateLimit;
using CustomTemplateAPI.Filters;
using CustomTemplateAPI.Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTemplateAPI
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
            services.ApiRateLimit();
            services.CustomCORS();
            services.CustomInfraStructure();
            services.Configure<ApiBehaviorOptions>(c =>
            {
                //this is because the apicontroller attribute automatically do the validation and it cause the request pointer return the request from
                //entering the action filter which is customised for custom validations.
                c.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers(c =>
            {
                //adds a filter as a service globally
                c.Filters.AddService<CustomValidationFilterAttribute>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomTemplateAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseIpRateLimiting();
            app.UseClientRateLimiting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomTemplateAPI v1"));
            }
            app.GlobalErrorHandler();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
