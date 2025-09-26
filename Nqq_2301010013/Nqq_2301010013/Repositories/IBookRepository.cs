using Nqq_2301010013.Controllers.DTO;
using Nqq_2301010013.Model.Domain;

public interface IBookRepository
{
    List<BookDTO> GetAllBooks(
        string? filterOn = null,
        string? filterQuery = null,
        string? sortBy = null,
        bool isAscending = true,
        int pageNumber = 1,
        int pageSize = 1000
    );

    BookDTO GetBookById(int id);
    addBookRequestDTO? AddBook(addBookRequestDTO addBookRequestDTO);
    addBookRequestDTO? UpdateBookById(int id, addBookRequestDTO bookDTO);
    Books? DeleteBookById(int id);
}
