using System.Text.Json;
namespace WinterWhispers.DAL
{
    public class TopicManagerAPI
    {

        private static Uri BaseAddress = new Uri("https://apiwinterwhispers.azurewebsites.net/");  
        public static async Task<List<Models.Topic>> GetAllTopics()
        {
            List<Models.Topic> topics = new List<Models.Topic>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                HttpResponseMessage response = await client.GetAsync("api/Topics");
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    topics = JsonSerializer.Deserialize<List<Models.Topic>>(responseString);
                }
                return topics;
            }
        }
    }
}
