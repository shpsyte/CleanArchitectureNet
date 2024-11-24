using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.GetSubscription;

public record GetSubscriptionQuery(Guid Id) : IRequest<ErrorOr<Subscription>>;
