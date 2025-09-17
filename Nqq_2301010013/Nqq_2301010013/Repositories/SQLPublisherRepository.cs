using Nqq_2301010013.Controllers.DTO;
using Nqq_2301010013.Data;
using Nqq_2301010013.Model.Domain;

namespace Nqq_2301010013.Repositories
{
    public class SQLPublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _dbContext;

        public SQLPublisherRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy tất cả publishers
        public List<PublisherDTO> GetAllPublishers()
        {
            return _dbContext.Publishers
                .Select(p => new PublisherDTO
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();
        }

        // Lấy publisher theo ID
        public PublisherDTO? GetPublisherById(int id)
        {
            var publisher = _dbContext.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher == null) return null;

            return new PublisherDTO
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }

        // Thêm publisher
        public PublisherDTO AddPublisher(AddPublisherRequestDTO dto)
        {
            var publisher = new Publisher
            {
                Name = dto.Name
            };

            _dbContext.Publishers.Add(publisher);
            _dbContext.SaveChanges();

            return new PublisherDTO
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }

        // Cập nhật publisher
        public PublisherDTO? UpdatePublisherById(int id, AddPublisherRequestDTO dto)
        {
            var publisher = _dbContext.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher == null) return null;

            publisher.Name = dto.Name;
            _dbContext.SaveChanges();

            return new PublisherDTO
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }

        // Xóa publisher
        public PublisherDTO? DeletePublisherById(int id)
        {
            var publisher = _dbContext.Publishers.FirstOrDefault(p => p.Id == id);
            if (publisher == null) return null;

            _dbContext.Publishers.Remove(publisher);
            _dbContext.SaveChanges();

            return new PublisherDTO
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }
    }
}
