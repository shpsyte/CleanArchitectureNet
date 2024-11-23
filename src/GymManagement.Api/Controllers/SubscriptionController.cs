using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
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
        var command = new CreateSubscriptionCommand(
             request.SubscriptionTye.ToString(), 
             request.AdminId);
        
        var createSubscriptionResult = await mediator.Send(command);
        
        return createSubscriptionResult.MatchFirst(
        guid => Ok(new SubscriptionResponse(guid, request.SubscriptionTye)),
        error => Problem()
        );

    }
}