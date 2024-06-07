using System.Text.Json.Serialization;

namespace WinterWhispers.Models
{
    public class Topic
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


    }
}
