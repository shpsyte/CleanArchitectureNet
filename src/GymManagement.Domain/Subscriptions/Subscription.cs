namespace GymManagement.Domain.Subscriptions;

public class Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null)
{
    private readonly Guid _adminid = adminId;
    public Guid Id { get; } = id ?? Guid.NewGuid();
    public SubscriptionType SubscriptionType { get; } = subscriptionType;
}