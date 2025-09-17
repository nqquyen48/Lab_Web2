using Microsoft.EntityFrameworkCore;
using Nqq_2301010013.Data;
using Nqq_2301010013.Model.Domain;
using Nqq_2301010013.Controllers.DTO;

namespace Nqq_2301010013.Repositories
{
    public class SQLAuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public SQLAuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // ✅ Lấy danh sách tất cả tác giả
        public List<AuthorDTO> GetAllAuthors()
        {
            return _dbContext.Authors
                .Select(a => new AuthorDTO
                {
                    Id = a.Id,
                    FullName = a.FullName
                }).ToList();
        }

        // ✅ Lấy tác giả theo Id
        public AuthorDTO? GetAuthorById(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return null;

            return new AuthorDTO
            {
                Id = author.Id,
                FullName = author.FullName
            };
        }

        // ✅ Thêm mới tác giả
        public AuthorDTO AddAuthor(AddAuthorRequestDTO dto)
        {
            var author = new Author
            {
                FullName = dto.FullName
            };

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

            return new AuthorDTO
            {
                Id = author.Id,
                FullName = author.FullName
            };
        }

        // ✅ Cập nhật tác giả theo Id
        public AuthorDTO? UpdateAuthorById(int id, AuthorNoIdDTO dto)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return null;

            author.FullName = dto.FullName;
            _dbContext.SaveChanges();

            return new AuthorDTO
            {
                Id = author.Id,
                FullName = author.FullName
            };
        }

        // ✅ Xóa tác giả theo Id
        public AuthorDTO? DeleteAuthorById(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return null;

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();

            return new AuthorDTO
            {
                Id = author.Id,
                FullName = author.FullName
            };
        }
    }
}
