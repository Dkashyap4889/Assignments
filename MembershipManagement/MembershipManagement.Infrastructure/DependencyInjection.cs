using MembershipManagement.Application.Common.Interfaces;
using MembershipManagement.Application.Notifications.Services;
using MembershipManagement.Infrastructure.Events;
using MembershipManagement.Infrastructure.Persistence;
using MembershipManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MembershipManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString(
                    "DefaultConnection")));

        services.AddScoped<IMembershipRepository,
            MembershipRepository>();
        services.AddScoped<IDomainEventDispatcher,
    DomainEventDispatcher>();
        return services;

    }
}