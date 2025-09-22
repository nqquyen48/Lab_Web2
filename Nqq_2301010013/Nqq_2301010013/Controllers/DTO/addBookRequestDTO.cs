using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nqq_2301010013.Controllers.DTO
{
    public class addBookRequestDTO
    {
        [Required]
        [MinLength(10)]
        [RegularExpression(@"^[a-zA-Z0-9\s,.!?-]*$", ErrorMessage = "Title cannot contain special characters.")]
        public string Title { get; set; }
        //[Required]
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        //[Range(0,5)]
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        // Navigation Properties
        public int PublisherID { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
