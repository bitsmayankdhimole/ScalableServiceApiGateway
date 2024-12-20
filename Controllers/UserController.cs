﻿using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ScalableServiceApiGateway.Models.Requests;
using ScalableServiceApiGateway.Models.Responses;
using System.Text.Json;

namespace ScalableServiceApiGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public UserController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["MicroserviceUrls:UserBaseUrl"];
        }

        [HttpPost("fetchUser")]
        public async Task<ActionResult<UserResponse>> FetchUser([FromHeader(Name = "auth-token")] string authToken)
        {
            _httpClient.DefaultRequestHeaders.Add("auth-token", authToken);
            var response = await _httpClient.GetAsync($"{_baseUrl}/user/fetchUser");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var userResponse = JsonSerializer.Deserialize<UserResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(userResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] Models.Requests.RegisterRequest request)
        {
            
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/auth/register", request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                var authResponse = JsonSerializer.Deserialize<AuthResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(authResponse);
            }
            catch (JsonException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] Models.Requests.LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/auth/login", request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var authResponse = JsonSerializer.Deserialize<AuthResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(authResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPost("request-password-change")]
        public async Task<ActionResult<PasswordChangeResponse>> RequestPasswordChange([FromBody] PasswordChangeRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/auth/RequestPasswordChange", request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var passwordChangeResponse = JsonSerializer.Deserialize<PasswordChangeResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(passwordChangeResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<AuthResponse>> ResetPassword([FromBody] Models.Requests.ResetPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/auth/ResetPassword", request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var authResponse = JsonSerializer.Deserialize<AuthResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(authResponse);
            }
            catch (JsonException ex)
            {
                
                return BadRequest("Error deserializing response.");
            }
        }
    }
}

