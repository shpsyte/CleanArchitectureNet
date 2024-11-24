using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistence;
using GymManagement.Infrastructure.Subscription.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<GymManagementDbContext>(o =>
        {
            o.UseSqlite("Data Source=gym.db");
        });
        services.AddScoped<ISubscriptionRepository, SubscriptionsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider =>
            serviceProvider.GetRequiredService<GymManagementDbContext>());
        return services;
    }

}