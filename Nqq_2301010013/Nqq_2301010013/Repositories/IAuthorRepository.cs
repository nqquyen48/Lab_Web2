using Nqq_2301010013.Controllers.DTO;

namespace Nqq_2301010013.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GetAllAuthors();
        AuthorDTO? GetAuthorById(int id);
        AuthorDTO AddAuthor(AddAuthorRequestDTO dto);
        AuthorDTO? UpdateAuthorById(int id, AuthorNoIdDTO dto);
        AuthorDTO? DeleteAuthorById(int id);
    }
}
