﻿using System.ComponentModel.DataAnnotations;

namespace Nqq_2301010013.Model.Domain
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        // Navigation Properties - One publisher has many books
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }

        // Navigation Properties - One book has many book_author
        public List<Book_Author> Book_Authors { get; set; }
    }
}
