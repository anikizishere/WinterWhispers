namespace WinterWhispers.Models
{
    public class Comment
    {
        //används inte just nu

        public int Id { get; set; }
        public int PostId { get; set; } /*för att kommentaren ska hamna under rätt inlägg*/
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
