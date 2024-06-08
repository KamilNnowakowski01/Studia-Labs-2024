using AutoMapper;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;
using Labs2024_Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public async Task<CarDTO> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            return _mapper.Map<CarDTO>(car);
        }

        public async Task AddCarAsync(CarDTO carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.AddCarAsync(car);
        }

        public async Task UpdateCarAsync(CarDTO carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteCarAsync(id);
        }
    }
}
