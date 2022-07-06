using IzleciDepresiju.Api.Core;
using IzleciDepresiju.API.Extensions;
using IzleciDepresiju.Application.Logging;
using IzleciDepresiju.Implementation;
using IzleciDepresiju.Implementation.DataAccess;
using IzleciDepresiju.Implementation.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
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

namespace IzleciDepresiju.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IzleciDepresiju.API", Version = "v1" });
            });
            services.AddTransient<IzleciDepresijuDbContext>();
            var settings = new AppSettings();
            Configuration.Bind(settings);
            services.AddHttpContextAccessor();
            services.AddJwt(settings);
            services.AddApplicationUser();
            services.AddUseCases();
            services.AddValidators();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IzleciDepresiju.API v1"));
            }

            app.UseRouting();
            CorsPolicyBuilder c = new CorsPolicyBuilder();
            app.UseCors(c => {
                c.AllowAnyMethod();
                c.AllowAnyHeader();
                c.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
