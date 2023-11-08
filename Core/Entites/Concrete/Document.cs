namespace Core.Entites.Concrete
{
    public class Document : IEntity
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; }
        public long Size { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
    }
}
