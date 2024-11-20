﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using System.Threading.Tasks;

public class AuthorizationFilter : IAsyncActionFilter
{
    private readonly HttpClient _httpClient;
    private readonly string verifyToken = "https://localhost:5001/api/identity/verify-token/";
    public AuthorizationFilter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var response = await _httpClient.GetAsync($"{verifyToken}{token}");
        if (!response.IsSuccessStatusCode)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userId = await response.Content.ReadAsStringAsync();
        context.HttpContext.Items["UserId"] = userId;

        await next();
    }
}