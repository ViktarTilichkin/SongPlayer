namespace Server.Models
{
    public class File
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public File()
        { }

        public File(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
