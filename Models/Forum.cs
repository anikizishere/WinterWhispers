using System;
using System.Text.Json.Serialization;
using WinterWhispers.Areas.Identity.Data;

namespace WinterWhispers.Models
{
    public class Forum
    {
        //innehåll i varje inlägg, vi knyter varje inlägg till en användare        
        
        public int Id { get; set; } 
        public string UserId { get; set; }
        public WinterWhispersUser User { get; set; }
        public int? TopicId { get; set; }

        public Topic Topic { get; set; }

        //[Required] ?
        [JsonPropertyName("header")]
        public string Header { get; set; }
        
        public string Text { get; set; } 
        
        public string Image { get; set; }
       
        //[Required] ?
        [JsonPropertyName("date")]
        public DateTime Date { get; set; } 
        
        public bool Reported { get; set; } // om inläggen är anmälda eller ej.



    }
}
