using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nqq_2301010013.Controllers.DTO;
using Nqq_2301010013.Data;
using Nqq_2301010013.Model.Domain;

namespace Nqq_2301010013.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class BooksController : ControllerBase
        {
            private readonly AppDbContext _dbContext;

            public BooksController(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            // GET http://localhost:port/api/books/get-all-books
            [HttpGet("get-all-books")]
            public IActionResult GetAll()
            {
                var allBooksDomain = _dbContext.Books;

                var allBooksDTO = allBooksDomain.Select(Books => new BookDTO()
                {
                    Id = Books.Id,
                    Title = Books.Title,
                    Description = Books.Description,
                    IsRead = Books.IsRead,
                    DateRead = Books.IsRead ? Books.DateRead.Value: null,
                    Rate = Books.IsRead ? Books.Rate.Value : null,
                    Genre = Books.Genre,
                    CoverUrl = Books.CoverUrl,
                    DateAdded = Books.DateAdded,
                    PublisherName = Books.Publisher.Name,
                    AuthorNames = Books.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList();

                return Ok(allBooksDTO);
            }

            // GET http://localhost:port/api/books/get-book-by-id/1
            [HttpGet("get-book-by-id/{id}")]
            public IActionResult GetBookById([FromRoute] int id)
            {
                var bookWithDomain = _dbContext.Books.Where(n => n.Id == id);

                if (bookWithDomain == null)
                {
                    return NotFound();
                }

                var bookWithIdDTO = bookWithDomain.Select(book => new BookDTO()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.DateRead,
                    Rate = book.Rate,
                    Genre = book.Genre,
                    CoverUrl = book.CoverUrl,
                    DateAdded = book.DateAdded,
                    PublisherName = book.Publisher.Name,
                    AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
                });

                return Ok(bookWithIdDTO);
            }

        // POST http://localhost:port/api/books/add-book
            [HttpPost("add-book")]
            public IActionResult AddBook([FromBody] addBookRequestDTO addBookRequestDTO)
            {
                // map DTO -> Domain Model
                var bookDomainModel = new Books
                {
                    Title = addBookRequestDTO.Title,
                    Description = addBookRequestDTO.Description,
                    IsRead = addBookRequestDTO.IsRead,
                    DateRead = addBookRequestDTO.DateRead,
                    Rate = addBookRequestDTO.Rate,
                    Genre = addBookRequestDTO.Genre,
                    CoverUrl = addBookRequestDTO.CoverUrl,
                    DateAdded = addBookRequestDTO.DateAdded,
                    PublisherID = addBookRequestDTO.PublisherID
                };

                // thêm sách
                _dbContext.Books.Add(bookDomainModel);
                _dbContext.SaveChanges();

                // thêm quan hệ Book - Author
                foreach (var id in addBookRequestDTO.AuthorIds)
                {
                    var _book_author = new Book_Author()
                    {
                        BookId = bookDomainModel.Id,
                        AuthorId = id
                    };

                    _dbContext.Books_Authors.Add(_book_author);
                    _dbContext.SaveChanges();
                }

                return Ok();
            }

            // PUT http://localhost:port/api/books/update-book-by-id/1
            [HttpPut("update-book-by-id/{id}")]
            public IActionResult UpdateBookById(int id, [FromBody] addBookRequestDTO bookDTO)
            {
                var bookDomain = _dbContext.Books.FirstOrDefault(n => n.Id == id);
                if (bookDomain != null)
                {
                    bookDomain.Title = bookDTO.Title;
                    bookDomain.Description = bookDTO.Description;
                    bookDomain.IsRead = bookDTO.IsRead;
                    bookDomain.DateRead = bookDTO.DateRead;
                    bookDomain.Rate = bookDTO.Rate;
                    bookDomain.Genre = bookDTO.Genre;
                    bookDomain.CoverUrl = bookDTO.CoverUrl;
                    bookDomain.DateAdded = bookDTO.DateAdded;
                    bookDomain.PublisherID = bookDTO.PublisherID;
                    _dbContext.SaveChanges();
                }

                var authorDomain = _dbContext.Books_Authors.Where(a => a.BookId == id).ToList();
                if (authorDomain != null)
                {
                    _dbContext.Books_Authors.RemoveRange(authorDomain);
                    _dbContext.SaveChanges();
                }

                foreach (var authorid in bookDTO.AuthorIds)
                {
                    var _book_author = new Book_Author()
                    {
                        BookId = id,
                        AuthorId = authorid
                    };
                    _dbContext.Books_Authors.Add(_book_author);
                    _dbContext.SaveChanges();
                }
                return Ok(bookDTO);
            }

            // DELETE http://localhost:port/api/books/delete-book-by-id/1
            [HttpDelete("delete-book-by-id/{id}")]
            public IActionResult DeleteBookById(int id)
            {
                var bookDomain = _dbContext.Books.FirstOrDefault(n => n.Id == id);
                if (bookDomain != null)
                {
                    _dbContext.Books.Remove(bookDomain);
                    _dbContext.SaveChanges();
                }
                return Ok();
            }
        }
    }


