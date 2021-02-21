using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parkbee.Application.Common.Interfaces;
using Parkbee.Infrastructure.ExternalDoorApiClient;
using Parkbee.Infrastructure.Identity;
using Parkbee.Infrastructure.Persistence;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Parkbee.Infrastructure
{
    public static class ConfigureServices
    {
        private static readonly Random Jitterer = new();
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IDoorApiClient, DoorApiClient>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddHttpClient<IDoorApiClient, DoorApiClient>(config =>
            //config.BaseAddress = new Uri(configuration.GetValue<string>("ExternalApiService:BaseUrl")))
            //    .SetHandlerLifetime(TimeSpan.FromMinutes(30))
            //    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            //    {
            //        Credentials = CredentialCache.DefaultCredentials,
            //    })
            //    .AddPolicyHandler(GetRetryPolicy());

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                2,
                retryAttempt => TimeSpan.FromSeconds(
                    Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(Jitterer.Next(0, 100)));
        }
    }
}
