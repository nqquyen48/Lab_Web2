using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nqq_2301010013.Controllers.DTO
{
    public class AddPublisherRequestDTO
    {
        [Required(ErrorMessage = "Publisher name is required.")]
        public string Name { set; get; }
    }
}
