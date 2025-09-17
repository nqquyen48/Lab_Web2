using Microsoft.AspNetCore.Mvc;
using Nqq_2301010013.Repositories;
using Nqq_2301010013.Controllers.DTO;

namespace Nqq_2301010013.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAll()
        {
            var authors = _authorRepository.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost("add-author")]
        public IActionResult Add(AddAuthorRequestDTO dto)
        {
            var newAuthor = _authorRepository.AddAuthor(dto);
            return Ok(newAuthor);
        }

        [HttpPut("update-author-by-id/{id}")]
        public IActionResult Update(int id, AuthorNoIdDTO dto)
        {
            var updated = _authorRepository.UpdateAuthorById(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _authorRepository.DeleteAuthorById(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
