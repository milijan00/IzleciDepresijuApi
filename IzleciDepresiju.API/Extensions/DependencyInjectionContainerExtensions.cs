using IzleciDepresiju.Api.Core;
using IzleciDepresiju.Application.UseCases.Commands;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Domain;
using IzleciDepresiju.Implementation.DataAccess;
using IzleciDepresiju.Implementation.UseCases.Ef.Commands;
using IzleciDepresiju.Implementation.UseCases.Ef.Queries;
using IzleciDepresiju.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IzleciDepresiju.API.Extensions
{
    public static class DependencyInjectionContainerExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<IzleciDepresijuDbContext>();

                return new JwtManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = accessor.HttpContext.User;

                if(claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUpdateRoleUseCasesCommand, EfUpdateRoleUseCasesCommand>();
            services.AddTransient<ICreateUseCaseCommand, EfCreateUseCaseCommand>();
            services.AddTransient<IGetNavigationLinksQuery, EfGetNavigationLinksQuery>();
            services.AddTransient<IGetWorkdaysQuery, EfGetWorkdaysQuery>();
            services.AddTransient<IGetTimesQuery, EfGetTimesQuery>();
            services.AddTransient<IGetDepressionSymptomsQuery, EfGetDepressionSymptomsQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetAvailableAppointmentsQuery, EfGetAvailableAppointmentsQuery>();
            services.AddTransient<IGetMadeAppointmentsQuery, EfGetMadeAppointmentsQuery>();
            services.AddTransient<IGetWorkdaysOfTherapistQuery, EfGetWorkdaysOfTherapistQuery>();
            services.AddTransient<IGetTimesFromAvailableAppointmentsQuery, EfGetTimesFromAvailableAppointmentQuery>();
            services.AddTransient<ICreateMadeAppointmentCommand, EfCreateMadeAppointmentCommand>();
            services.AddTransient<IGetSpecificMadeAppointmentsQuery, EfGetSpecificMadeAppointmentsQuery>();
            services.AddTransient<IDeleteMadeAppoointmentCommand, EfDeleteMadeAppointmentCommand>();
            services.AddTransient<IUpdateMadeAppointmentCommand, EfUpdateMadeAppointmentCommand>();
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<UpdateRoleUseCaseValidator>();
            services.AddTransient<SearchTimesValidator>();
            services.AddTransient<CreateUseCaseValidator>();
            services.AddTransient<UpdateMadeAppointmentValidator>();
        }

    }
}
