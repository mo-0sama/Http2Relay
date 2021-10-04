//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace HTTP2Relay.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private readonly HttpClient _client;
   
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//            _client = new HttpClient(new HttpClientHandler()
//            {
//                AllowAutoRedirect = false
//            });
//        }

//        [HttpGet]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            var rng = new Random();
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateTime.Now.AddDays(index),
//                TemperatureC = rng.Next(-20, 55),
//                Summary = Summaries[rng.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }
//        //[HttpPost]
//        //[Route("api/posts/{postId}")]
//        //public Task GetPosts(int postId)
//        //{
//        //    return this.ProxyAsync($"https://jsonplaceholder.typicode.com/posts/{postId}");
//        //}
//        [HttpPost]
//        public async Task POST()
//        {
//            var request = HttpContext.CreateProxyHttpRequest(new Uri(HttpContext.Request.Headers["RelayURL"]));
//            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, HttpContext.RequestAborted);
//            await HttpContext.CopyProxyHttpResponse(response);
            
//            //var xx = response.Version;
//        }
        
//    }
//}
