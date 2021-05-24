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
    public class PhotosController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PhotosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        [HttpGet]
        [Route("album/{albumId}")]
        public async Task<IActionResult> GetAllAsync(int albumId)
        {
            Console.WriteLine("***************************************accessing api***************************************");

            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/albums/" + albumId + "/photos");

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

            List<Photo> photos = JsonSerializer.Deserialize<List<Photo>>(responseString, options);
            
            return Ok(photos);

        }
    }
}