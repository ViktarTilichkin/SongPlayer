namespace Server.Models
{
    public class SongEntity
    {
        public int Id { get; set; }
        public string NameSong { get; set; }
        public string Singer { get; set; } 
        public string Path { get; set; }
        public int OwnerId { get; set; }
        public int GenreId { get; set;}
        public int Visibility { get; set; } 
    }
}
