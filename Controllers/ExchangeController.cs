using Microsoft.AspNetCore.Mvc;
using ScalableServiceApiGateway.Models.Requests;
using ScalableServiceApiGateway.Models.Responses;
using System.Text.Json;

namespace ScalableServiceApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[ServiceFilter(typeof(AuthorizationFilter))]
    public class ExchangeController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ExchangeController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["MicroserviceUrls:ExchangeBaseUrl"];
        }

        [HttpGet("lookup/delivery-methods")]
        public async Task<ActionResult<List<Lookup>>> GetDeliveryMethods()
        {
            var userId = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/lookup/delivery-methods");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var deliveryMethods = JsonSerializer.Deserialize<List<Lookup>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(deliveryMethods);
            }
            catch (JsonException ex)
            {
                // Log the exception (ex) as needed
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpGet("lookup/payment-methods")]
        public async Task<ActionResult<List<Lookup>>> GetPaymentMethods()
        {
            var userId = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/lookup/payment-methods");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var paymentMethods = JsonSerializer.Deserialize<List<Lookup>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(paymentMethods);
            }
            catch (JsonException ex)
            {
                // Log the exception (ex) as needed
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpGet("lookup/statuses")]
        public async Task<ActionResult<List<Lookup>>> GetStatuses()
        {
            var userId = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/lookup/statuses");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var statuses = JsonSerializer.Deserialize<List<Lookup>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(statuses);
            }
            catch (JsonException ex)
            {
                // Log the exception (ex) as needed
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPost("exchange-requests")]
        public async Task<ActionResult<ExchangeRequest>> CreateExchangeRequest([FromBody] CreateExchangeRequest request)
        {
            var userId = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/ExchangeRequests", request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var exchangeRequest = JsonSerializer.Deserialize<ExchangeRequest>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(exchangeRequest);
            }
            catch (JsonException ex)
            {
                // Log the exception (ex) as needed
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpGet("exchange-requests/{requestId}")]
        public async Task<ActionResult<ExchangeRequest>> GetExchangeRequest(int requestId)
        {
            var userId = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/ExchangeRequests/{requestId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var exchangeRequest = JsonSerializer.Deserialize<ExchangeRequest>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(exchangeRequest);
            }
            catch (JsonException ex)
            {
                // Log the exception (ex) as needed
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpGet("exchange-requests")]
        public async Task<ActionResult<List<ExchangeRequest>>> GetExchangeRequests()
        {
            var userIdFromToken = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.GetAsync($"{_baseUrl}/api/ExchangeRequests?userId={userIdFromToken}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var exchangeRequests = JsonSerializer.Deserialize<List<ExchangeRequest>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(exchangeRequests);
            }
            catch (JsonException ex)
            {
                // Log the exception (ex) as needed
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPut("exchange-requests/{requestId}")]
        public async Task<IActionResult> UpdateExchangeRequest(int requestId, [FromBody] UpdateExchangeRequest request)
        {
            var userId = HttpContext.Items["UserId"] as string;

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/ExchangeRequests/{requestId}", request);
            response.EnsureSuccessStatusCode();
            return NoContent();
        }
    }
}
