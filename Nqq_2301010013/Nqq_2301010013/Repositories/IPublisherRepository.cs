using Nqq_2301010013.Controllers.DTO;

namespace Nqq_2301010013.Repositories
{
    public interface IPublisherRepository
    {
        List<PublisherDTO> GetAllPublishers();
        PublisherDTO? GetPublisherById(int id);
        PublisherDTO AddPublisher(AddPublisherRequestDTO dto);
        PublisherDTO? UpdatePublisherById(int id, AddPublisherRequestDTO dto);
        PublisherDTO? DeletePublisherById(int id);
    }
}
