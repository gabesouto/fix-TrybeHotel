using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetHotels()
        {
            var hotels = _repository.GetHotels();
            return Ok(hotels);
        }

        [HttpPost]
        [Authorize("admin")]
        public IActionResult PostHotel([FromBody] Hotel hotel)
        {

            var hotelAdded = _repository.AddHotel(hotel);
            return Created("hotel", hotelAdded);
        }


    }
}