using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistence;

namespace GymManagement.Infrastructure.Subscription.Persistence;

internal class SubscriptionsRepository(GymManagementDbContext dbContext) : ISubscriptionRepository
{
    public async Task Add(Domain.Subscriptions.Subscription subscription)
    {
        await dbContext.Subscriptions.AddAsync(subscription);
    }

    public async Task<Domain.Subscriptions.Subscription?> GetById(Guid id)
    {
        return await dbContext.Subscriptions.FindAsync(id);
    }
  
}