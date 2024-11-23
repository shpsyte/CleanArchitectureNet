using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController(ILogger<SubscriptionController> logger, ISubscriptionsService _subscriptionsService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateSubscription(CreateSubscriptionRequest request)
    {
        var subscriptionId =  _subscriptionsService.CreateSubscription(request.SubscriptionTye.ToString(), request.AdminId);

        var response = new SubscriptionResponse(subscriptionId, request.SubscriptionTye);
        return Ok(response);

    }
}