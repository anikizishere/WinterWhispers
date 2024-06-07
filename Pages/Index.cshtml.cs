using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;
using WinterWhispers.DAL;
using WinterWhispers.Models;

namespace WinterWhispers.Pages
{
    public class IndexModel : PageModel
    {
        public Areas.Identity.Data.WinterWhispersUser MyUser { get; set; } //denna används på webbsidan

        private UserManager <Areas.Identity.Data.WinterWhispersUser> _userManager { get; set; }         

        public IndexModel(UserManager<Areas.Identity.Data.WinterWhispersUser> userManager) // ....vi ber om en usermanager i en konstruktor
        {
            _userManager = userManager;
        }
        public List<Models.Topic> Topics { get; set; }

        public async Task OnGetAsync(int showTopic )
        {
            MyUser = await _userManager.GetUserAsync(User);
           
            Topics = await DAL.TopicManagerAPI.GetAllTopics();

            //if (showTopic != 0)
            //{
            //    Topics = await DAL.TopicManagerAPI.GetTopic(showTopic);
                
            //}

        }


        //public async Task<IActionResult> OnGetAsync()
        //{
            
        //}


        //using (var client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri("https://localhost:44300/"); /*är det den från webbsidan localhost:44337? eller swegger*/

        //    HttpResponseMessage response = await client.GetAsync("api/Topic");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string responseString = await response.Content.ReadAsStringAsync();
        //        topics = JsonSerializer.Deserialize<List<Models.Topic>>(responseString);
        //    }
        //}

       
        //public Models.Topic Topic { get; set; }


    }
}
