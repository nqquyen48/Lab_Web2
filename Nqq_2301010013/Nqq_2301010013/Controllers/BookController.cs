using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nqq_2301010013.Controllers.DTO;
using Nqq_2301010013.CustomActionFilter;
using Nqq_2301010013.Data;
using Nqq_2301010013.Model.Domain;
using Nqq_2301010013.Repositories;

namespace Nqq_2301010013.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBookRepository _bookRepository;

        public BooksController(AppDbContext dbContext, IBookRepository bookRepository)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAll()
        {
            // su dung reposity pattern  
            var allBooks = _bookRepository.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("get-book-by-id/{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            var bookWithIdDTO = _bookRepository.GetBookById(id);
            return Ok(bookWithIdDTO);
        }
        [HttpPost("add-book)")]
        [ValidateModel]
        public IActionResult AddBook([FromBody] addBookRequestDTO addBookRequestDTO)
        {

            if (ValidateAddBook(addBookRequestDTO))
            {
                var bookAdd = _bookRepository.AddBook(addBookRequestDTO);
                return Ok(bookAdd);
            }
            else return BadRequest(ModelState);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] addBookRequestDTO bookDTO)
        {
            var updateBook = _bookRepository.UpdateBookById(id, bookDTO);
            return Ok(updateBook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var deleteBook = _bookRepository.DeleteBookById(id);
            return Ok(deleteBook);
        }
        private bool ValidateAddBook(addBookRequestDTO addBookRequestDTO)
        {
            if (string.IsNullOrWhiteSpace(addBookRequestDTO.Title) || addBookRequestDTO.Title.Length <= 10)
            {
                ModelState.AddModelError(nameof(addBookRequestDTO.Title), $"{nameof(addBookRequestDTO.Title)} must be longer than 10 characters");
            }
            if (addBookRequestDTO == null)
            {
                ModelState.AddModelError(nameof(addBookRequestDTO), $"Please add book data");
                return false;
            }
            // kiem tra Description NotNull 
            if (string.IsNullOrEmpty(addBookRequestDTO.Description))
            {
                ModelState.AddModelError(nameof(addBookRequestDTO.Description), $"{nameof(addBookRequestDTO.Description)} cannot be null");
            }
            // kiem tra rating (0,5) 
            if (addBookRequestDTO.Rate < 0 || addBookRequestDTO.Rate > 5)
            {
                if (addBookRequestDTO.Rate < 0 || addBookRequestDTO.Rate > 5)
                {
                    ModelState.AddModelError(nameof(addBookRequestDTO.Rate),$"{nameof(addBookRequestDTO.Rate)} cannot be less than 0 and more than 5");
                }
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
    }
}
