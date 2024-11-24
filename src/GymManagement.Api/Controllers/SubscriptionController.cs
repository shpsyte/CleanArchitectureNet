using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Commands.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController(
    ILogger<SubscriptionController> logger, 
    ISender mediator   
    ) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        
        if (!Domain.Subscriptions.SubscriptionType.TryFromName(request.SubscriptionTye.ToString(), out var subscriptionType))
        {
            return Problem(statusCode: StatusCodes.Status400BadRequest, title: "Invalid subscription type"); 
        }
        
        
        var command = new CreateSubscriptionCommand(
            subscriptionType,
             request.AdminId);
        
        var createSubscriptionResult = await mediator.Send(command);
        
        return createSubscriptionResult.MatchFirst(
        subs => CreatedAtAction(
                    nameof(GetSubscription), 
                   new { subscriptionId = subs.Id }, 
                    new SubscriptionResponse(subs.Id, Enum.Parse<SubscriptionTye>(subs.SubscriptionType.Name))
                ),
        error => Problem()
        );

    }
    
    [HttpGet("{subscriptionId:guid}")]
    public async Task<IActionResult> GetSubscription(Guid subscriptionId)
    {
        var query = new GetSubscriptionQuery(subscriptionId);
        var subscription = await mediator.Send(query);
        
        return subscription.MatchFirst(
            subs => Ok(new SubscriptionResponse(
                subs.Id, Enum.Parse<SubscriptionTye>(subs.SubscriptionType.Name))),
            error => Problem()
        );
    }
}