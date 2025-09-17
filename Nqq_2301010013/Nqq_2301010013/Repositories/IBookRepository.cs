using Nqq_2301010013.Controllers.DTO;
using Nqq_2301010013.Model.Domain;

namespace Nqq_2301010013.Repositories
{
    public interface IBookRepository
    {
        List<BookDTO> GetAllBooks();
        BookDTO GetBookById(int id);
        addBookRequestDTO AddBook(addBookRequestDTO addBookRequestDTO);
        addBookRequestDTO? UpdateBookById(int id, addBookRequestDTO bookDTO);
        Books? DeleteBookById(int id);
    }
}
