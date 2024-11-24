using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.GetSubscription;

public class GetSubscriptionQueryHandler(
    ISubscriptionRepository subscriptionRepository)
    : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var subscription = await subscriptionRepository.GetById(request.Id);
        if (subscription is null)
        {
            return Error.NotFound(description: "404");
        }

        return subscription;
    }

 
}
