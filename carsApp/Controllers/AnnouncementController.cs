using carsApp.Interfaces;
using carsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace carsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementController(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Announcement>))]
        public IActionResult GetAll()
        {
            var announcement = _announcementRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(announcement);    
        }

        [HttpPost("filters")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Announcement>))]
        public IActionResult GetAllByFilters([FromBody] Filter[] filters)
        {
            Console.WriteLine(filters[0]);
            var announcement = _announcementRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(announcement);
        }


        [HttpGet("random/{n}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Announcement>))]
        public IActionResult GetNRandom(int n)
        {
            var announcement = _announcementRepository.GetNRandom(n);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(announcement);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Announcement))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id) {
            if (!_announcementRepository.Exist(id))
                return NotFound();

            var announcement = _announcementRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(announcement);    
        }
    }
}
