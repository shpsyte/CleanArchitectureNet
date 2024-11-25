using ErrorOr;

namespace GymManagement.Domain.Subscriptions;

public static class SubscritpionErrors
{
    public static readonly Error SubscriptionActivationCannotBeWithoutAdmin = Error.Validation(
        code: "SubscriptionActivationCannotBeWithoutAdmin", 
        description: "Free subscriptions can only be activated by an admin.");
    
}