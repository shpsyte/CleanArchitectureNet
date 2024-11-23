
namespace GymManagement.Contracts.Subscriptions;


public record CreateSubscriptionRequest(SubscriptionTye SubscriptionTye, Guid AdminId);