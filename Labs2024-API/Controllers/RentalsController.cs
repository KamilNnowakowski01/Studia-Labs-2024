using AutoMapper;
using Labs2024_Application.Services;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IMapper _mapper;

        public RentalsController(IRentalService rentalService, IMapper mapper)
        {
            _rentalService = rentalService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<RentalDTO>>> GetRentals()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<RentalDTO>> GetRental(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<RentalDTO>> AddRental(RentalDTO rentalDto)
        {
            await _rentalService.AddRentalAsync(rentalDto);
            return CreatedAtAction(nameof(GetRental), new { id = rentalDto.ID }, rentalDto);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateRental(int id, RentalDTO rentalDto)
        {
            if (id != rentalDto.ID)
            {
                return BadRequest();
            }

            await _rentalService.UpdateRentalAsync(rentalDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            await _rentalService.DeleteRentalAsync(id);
            return NoContent();
        }

        // Endpoint for renting a car
        [HttpPost("rent")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<IActionResult> RentCar(int userId, int carId)
        {
            var result = await _rentalService.RentCarAsync(userId, carId);
            if (result != "Car rented successfully.")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Endpoint for returning a car
        [HttpPost("return")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<IActionResult> ReturnCar(int userId, int carId)
        {
            var result = await _rentalService.ReturnCarAsync(userId, carId);
            if (result != "Car returned successfully.")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("rent")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetRentedCars()
        {
            var rentedCars = await _rentalService.GetRentedCarsAsync();
            return Ok(rentedCars);
        }
    }
}
