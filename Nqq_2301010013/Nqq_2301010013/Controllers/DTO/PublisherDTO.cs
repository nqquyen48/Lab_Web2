namespace Nqq_2301010013.Controllers.DTO
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class PublisherNoIdDTO
    {
        public string Name { get; set; }

    }
    // add model to get Book and Author 
    public class PublishDTO
    {
        public string Name { get; set; }
    }

    public class BookAuthorDTO
    {
        public string BookName { get; set; }

    }
}
