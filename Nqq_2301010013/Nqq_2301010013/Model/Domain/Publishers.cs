using System.ComponentModel.DataAnnotations;

namespace Nqq_2301010013.Model.Domain
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties – One publisher has many books
        public List<Books> Books { get; set; }
    }
}
