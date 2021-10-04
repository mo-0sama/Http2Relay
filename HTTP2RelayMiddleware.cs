using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTP2Relay
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HTTP2RelayMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HTTP2RelayMiddleware> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        //static readonly HttpClient _client=new HttpClient();
        public HTTP2RelayMiddleware(RequestDelegate next, ILogger<HTTP2RelayMiddleware> logger, IHttpClientFactory httpClientFactory)
        {
            _next = next;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var newUrl = httpContext.Request.Headers["RelayURL"];
            if (string.IsNullOrEmpty(newUrl))
            {
                _logger.LogInformation($"RelayURL Doesn't Exist");
                await httpContext.Response.WriteAsync($"<h1 style='color:red;'>You don't allow to use this api</h1>");
            }
            else
            {
                _logger.LogInformation($"Start Handle Request : {newUrl}");
                var _client = _httpClientFactory.CreateClient();
                var request = httpContext.CreateProxyHttpRequest(new Uri(httpContext.Request.Headers["RelayURL"]));
                var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, httpContext.RequestAborted);
                await httpContext.CopyProxyHttpResponse(response);
                _logger.LogInformation($"Request executing done with response code : {httpContext.Response.StatusCode}");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HTTP2RelayMiddlewareExtensions
    {
        public static IApplicationBuilder UseHTTP2RelayMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HTTP2RelayMiddleware>();
        }
    }
}
