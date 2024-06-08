using AutoMapper;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;
using Labs2024_Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository, ICarRepository carRepository, IUserRepository userRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RentalDTO>> GetAllRentalsAsync()
        {
            var rentals = await _rentalRepository.GetAllRentalsAsync();
            return _mapper.Map<IEnumerable<RentalDTO>>(rentals);
        }

        public async Task<RentalDTO> GetRentalByIdAsync(int id)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(id);
            return _mapper.Map<RentalDTO>(rental);
        }

        public async Task AddRentalAsync(RentalDTO rentalDto)
        {
            var rental = _mapper.Map<Rental>(rentalDto);
            await _rentalRepository.AddRentalAsync(rental);
        }

        public async Task UpdateRentalAsync(RentalDTO rentalDto)
        {
            var rental = _mapper.Map<Rental>(rentalDto);
            await _rentalRepository.UpdateRentalAsync(rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _rentalRepository.DeleteRentalAsync(id);
        }

        public async Task<string> RentCarAsync(int userId, int carId)
        {
            // Check if car is already rented
            var activeRental = await _rentalRepository.GetActiveRentalForCarAsync(carId);
            if (activeRental != null)
            {
                return "Car is already rented.";
            }

            // Check if user has an active rental
            var userRental = await _rentalRepository.GetActiveRentalForUserAsync(userId);
            if (userRental != null)
            {
                return "User already has an active rental.";
            }

            var rental = new Rental
            {
                ID = 0,
                IDUser = userId,
                IDCar = carId,
                State = RentalState.Rented,
                DateStartRental = DateTime.Now
            };

            await _rentalRepository.AddRentalAsync(rental);
            return "Car rented successfully.";
        }

        public async Task<string> ReturnCarAsync(int userId, int carId)
        {
            var activeRental = await _rentalRepository.GetActiveRentalForCarAsync(carId);
            if (activeRental == null || activeRental.IDUser != userId)
            {
                return "No active rental found for this car and user.";
            }

            activeRental.State = RentalState.Returned;
            activeRental.DateCloseRental = DateTime.Now;

            await _rentalRepository.UpdateRentalAsync(activeRental);
            return "Car returned successfully.";
        }

        public async Task<IEnumerable<CarDTO>> GetRentedCarsAsync()
        {
            var rentedCars = await _rentalRepository.GetAllRentalsAsync();
            var rentedCarIds = rentedCars.Select(r => r.IDCar).Distinct();
            var cars = await _carRepository.GetAllCarsAsync();
            var rentedCarEntities = cars.Where(c => rentedCarIds.Contains(c.ID));
            return _mapper.Map<IEnumerable<CarDTO>>(rentedCarEntities);
        }
    }
}
