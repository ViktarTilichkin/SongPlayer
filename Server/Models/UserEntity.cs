namespace Server.Models
{
    public enum VisualThema
    {
        Base,
        Custom
    }

    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public int VisualThema { get; set; }
    }

}
