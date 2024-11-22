using Microsoft.AspNetCore.Mvc;
using ScalableServiceApiGateway.Models;
using ScalableServiceApiGateway.Models.Requests;
using ScalableServiceApiGateway.Models.Responses;
using System.Text.Json;

namespace ScalableServiceApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class BookController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public BookController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["MicroserviceUrls:BookBaseUrl"];
        }

        [HttpPost]
        public async Task<ActionResult<BookResponse>> CreateBook([FromBody] CreateBookRequest request)
        {
            var userId = HttpContext.Items["UserId"] as string;

            var requestBody = new CreateBookMicroserviceRequest
            {
                Author = request.Author,
                Condition = request.Condition,
                Description = request.Description,
                Genre = request.Genre,
                IsAvailable = request.IsAvailable,
                Location = request.Location,
                Title = request.Title,
                UserId = userId
            };

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/books", requestBody);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var bookResponse = JsonSerializer.Deserialize<PostBook>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(bookResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPost("advanced-search")]
        public async Task<ActionResult<AdvancedSearchResponse>> AdvancedSearch([FromBody] AdvancedSearchRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/books/advanced-search", request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var searchResponse = JsonSerializer.Deserialize<AdvancedSearchResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(searchResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/books");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var books = JsonSerializer.Deserialize<BookResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(books);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult<BookResponse>> UpdateBook(string bookId, [FromBody] UpdateBookRequest request)
        {
            var userId = HttpContext.Items["UserId"] as string;

            var requestBody = new UpdateBookMicroServiceRequest
            {
                Condition = request.Condition,
                IsAvailable = request.IsAvailable,
                UserId = userId
            };

            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/books/{bookId}", requestBody);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var bookResponse = JsonSerializer.Deserialize<PostBook>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(bookResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<BookResponse>> GetBook(string bookId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/books/{bookId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var bookResponse = JsonSerializer.Deserialize<GetBook>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(bookResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }
    }
}
