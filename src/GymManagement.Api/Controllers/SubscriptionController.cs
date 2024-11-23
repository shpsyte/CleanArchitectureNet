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
        
        var subscriptionId = await mediator.Send(command);
      
        var response = new SubscriptionResponse(subscriptionId, request.SubscriptionTye);
        return Ok(response);
    }
}