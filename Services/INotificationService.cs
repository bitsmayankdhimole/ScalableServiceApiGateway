using ScalableServiceApiGateway.Models.Requests;
using ScalableServiceApiGateway.Models.Responses;
using System.Threading.Tasks;

namespace ScalableServiceApiGateway.Services
{
    public interface INotificationService
    {
        Task<NotificationResponse> SendNotification(CreateNotificationRequest request);
    }
}
