using carsApp.Interfaces;
using carsApp.Models;
using carsApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace carsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController: Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public IActionResult GetAll()
        {
            var cars = _carRepository.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(cars);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Car))]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            if (!_carRepository.Exist(id))
                return NotFound();

            var announcement = _carRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(announcement);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] Car car)
        {
            if (car == null)            
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.Create(car))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return BadRequest(ModelState);
            }
            return Ok("Successyfully created");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteById(int id)
        {
            if (!_carRepository.Exist(id)) 
                return NotFound();
            Car car = _carRepository.GetById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.Delete(car))
            {
                ModelState.AddModelError("", "something went wrong while deleting");
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}
