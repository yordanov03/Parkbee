using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Parkbee.Application.Common.Interfaces;
using Parkbee.Domain.Entities;
using Parkbee.Infrastructure.Identity;
using Parkbee.Infrastructure.Persistence.Interceptors;
using System;
using System.Reflection;

namespace Parkbee.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly AuditEntitiesSaveChangesInterceptor _auditEntitiesSaveChangesInterceptor;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {

            _auditEntitiesSaveChangesInterceptor =
                new AuditEntitiesSaveChangesInterceptor(currentUserService);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<Door> Doors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableDetailedErrors();
            optionsBuilder.LogTo(Console.WriteLine);

            optionsBuilder.AddInterceptors(_auditEntitiesSaveChangesInterceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
