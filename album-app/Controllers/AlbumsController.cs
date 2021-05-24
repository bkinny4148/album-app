using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using album_app.Models;

namespace album_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AlbumsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetAllAsync(int userId)
        {
            Console.WriteLine("***************************************accessing api***************************************");

            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/users/" + userId + "/albums");

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Album> albums = JsonSerializer.Deserialize<List<Album>>(responseString, options);
            
            return Ok(albums);

        }
    }
}