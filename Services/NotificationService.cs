using ScalableServiceApiGateway.Models.Requests;
using ScalableServiceApiGateway.Models.Responses;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ScalableServiceApiGateway.Services
{

    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public NotificationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["MicroserviceUrls:NotificationBaseUrl"];
        }

        public async Task<NotificationResponse> SendNotification(CreateNotificationRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/v1/notification/email", request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return new NotificationResponse()
                {
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
                    Message = content,
                    Recipient = request.Recipient,
                    Status = "Success",
                    Type = request.Type
                };
            }
            catch (Exception ex)
            {
                return new NotificationResponse();
            }
            //return JsonSerializer.Deserialize<NotificationResponse>(content, new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //});
        }
    }
}
