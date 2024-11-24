using MediatR;

using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler(
    ISubscriptionRepository subscriptionRepository,
    IUnitOfWork unitOfWork 
    )
    : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        // create subscription
        var subscription = new Subscription(request.SubscriptionType, request.AdminId);
        
        // add it to the database
        await subscriptionRepository.Add(subscription);
        await unitOfWork.CommitAsync(cancellationToken);
        
        
        // return the subscription
        return subscription;
    }
}
