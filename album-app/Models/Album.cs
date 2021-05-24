using System.Text.Json.Serialization;

namespace album_app.Models
{
    public class Album
    {
        [JsonPropertyName("id")]
        public int AlbumId { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}