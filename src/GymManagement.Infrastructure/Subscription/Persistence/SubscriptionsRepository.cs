using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Infrastructure.Subscription.Persistence;

public class SubscriptionsRepository : ISubscriptionRepository
{
    private static readonly List<Domain.Subscriptions.Subscription> _subscriptions = [];
    public Task Add(Domain.Subscriptions.Subscription subscription)
    {
        _subscriptions.Add(subscription);
        return Task.CompletedTask;
    }

    public Task<Domain.Subscriptions.Subscription?> GetById(Guid id)
    {
        var subscription = _subscriptions.Find(x => x.Id == id);
        return Task.FromResult(subscription);


    }
}