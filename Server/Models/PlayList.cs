namespace Server.Models
{
    public class PlayList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<Description> Description { get; set; }
    }
}
