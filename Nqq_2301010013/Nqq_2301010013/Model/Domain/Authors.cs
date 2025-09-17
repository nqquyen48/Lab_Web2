using System.ComponentModel.DataAnnotations;

namespace Nqq_2301010013.Model.Domain
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

        // Navigation properties – One author has many book_author
        public ICollection<Book_Author>? Book_Authors { get; set; }
    }
}
