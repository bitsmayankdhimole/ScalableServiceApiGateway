using Microsoft.AspNetCore.Mvc;
using ScalableServiceApiGateway.Models.Requests;
using ScalableServiceApiGateway.Models.Responses;
using ScalableServiceApiGateway.Services;
using System.Text.Json;

namespace ScalableServiceApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("email")]
        [ServiceFilter(typeof(AuthorizationFilter))]
        public async Task<ActionResult<NotificationResponse>> CreateNotification([FromBody] CreateNotificationRequest request)
        {
            try
            {
                var notificationResponse = await _notificationService.SendNotification(request);
                return Ok(notificationResponse);
            }
            catch (JsonException ex)
            {
                return BadRequest("Error deserializing response.");
            }
        }
    }
}
