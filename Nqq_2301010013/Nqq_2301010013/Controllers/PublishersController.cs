using Microsoft.AspNetCore.Mvc;
using Nqq_2301010013.Controllers.DTO;
using Nqq_2301010013.Repositories;

namespace Nqq_2301010013.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAll()
        {
            var publishers = _publisherRepository.GetAllPublishers();
            return Ok(publishers);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost("add-publisher")]
        public IActionResult Add(AddPublisherRequestDTO dto)
        {
            var added = _publisherRepository.AddPublisher(dto);
            return Ok(added);
        }

        [HttpPut("update-publisher-by-id/{id}")]
        public IActionResult Update(int id, AddPublisherRequestDTO dto)
        {
            var updated = _publisherRepository.UpdatePublisherById(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _publisherRepository.DeletePublisherById(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
