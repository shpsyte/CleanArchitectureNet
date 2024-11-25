
namespace GymManagement.Contracts.Subscriptions;


public record CreateSubscriptionRequest(SubscriptionTye SubscriptionType, Guid AdminId);