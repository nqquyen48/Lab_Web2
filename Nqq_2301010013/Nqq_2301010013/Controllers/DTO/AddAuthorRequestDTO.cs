using System.ComponentModel.DataAnnotations;

namespace Nqq_2301010013.Controllers.DTO
{
    public class AddAuthorRequestDTO
    {
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Name must be exactly 3 characters.")]
        public string FullName { set; get; }
    }
}
