using System.Text.Json.Serialization;

namespace album_app.Models
{
    public class Photo
    {
        [JsonPropertyName("id")]
        public int AlbumId { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
 
    }
}