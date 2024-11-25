using ErrorOr;
using Throw;

namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly Guid _adminId;
    public Guid Id { get; private set; }
    public SubscriptionType SubscriptionType { get; private set; } 
    
    public Subscription(SubscriptionType subscriptionType, Guid adminId, Guid? id = null) : this()
    {
        Id = id ?? Guid.NewGuid();
        SubscriptionType = subscriptionType;
        _adminId = adminId;
    }
    
    public ErrorOr<Success> Validate()
    {
        Id.Throw().IfEquals(Guid.Empty);
        
        if (this.SubscriptionType == SubscriptionType.Free && _adminId == Guid.Empty)
        {
            return SubscritpionErrors.SubscriptionActivationCannotBeWithoutAdmin;
        }

        return Result.Success;
    }

    private Subscription() { }
}