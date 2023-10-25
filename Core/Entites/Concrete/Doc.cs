namespace Core.Entites.Concrete
{
    public class Doc : IEntity
    {
        public byte[] fileContent { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public string path { get; set; }
    }
}
