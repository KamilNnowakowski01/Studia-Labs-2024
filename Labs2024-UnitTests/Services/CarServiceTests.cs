using AutoMapper;
using Labs2024_Application.Services;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;
using Labs2024_Infrastructure.Repositories;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Labs2024_UnitTests.Services
{
    [TestFixture]
    public class CarServiceTests
    {
        private Mock<ICarRepository> _carRepositoryMock;
        private CarService _carService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _carRepositoryMock = new Mock<ICarRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarDTO, Car>();
                cfg.CreateMap<Car, CarDTO>();
            });

            _mapper = config.CreateMapper();
            _carService = new CarService(_carRepositoryMock.Object, _mapper);
        }

        [Test]
        public async Task GetAllCarsAsync_ReturnsAllCars()
        {
            // Arrange
            var cars = new List<Car>
            {
                new Car { ID = 1, Brand = "Toyota", Model = "Corolla", YearOfProduction = 2019, CarRegistration = "ABC123" },
                new Car { ID = 2, Brand = "Honda", Model = "Civic", YearOfProduction = 2020, CarRegistration = "XYZ789" }
            };

            _carRepositoryMock.Setup(repo => repo.GetAllCarsAsync()).ReturnsAsync(cars);

            // Act
            var result = await _carService.GetAllCarsAsync();

            // Assert
            //Assert.AreEqual(2, result.Count());
            ClassicAssert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetCarByIdAsync_ReturnsCar()
        {
            // Arrange
            var car = new Car { ID = 1, Brand = "Toyota", Model = "Corolla", YearOfProduction = 2019, CarRegistration = "ABC123" };
            _carRepositoryMock.Setup(repo => repo.GetCarByIdAsync(1)).ReturnsAsync(car);

            // Act
            var result = await _carService.GetCarByIdAsync(1);

            // Assert
            //Assert.AreEqual("Toyota", result.Brand);
            ClassicAssert.AreEqual("Toyota", result.Brand);
        }

        [Test]
        public async Task CreateCarAsync_CreatesCar()
        {
            // Arrange
            var carDto = new CarDTO
            {
                ID = 1,
                Brand = "Toyota",
                Model = "Corolla",
                YearOfProduction = 2019,
                CarRegistration = "ABC123"
            };

            var car = new Car
            {
                ID = carDto.ID,
                Brand = carDto.Brand,
                Model = carDto.Model,
                YearOfProduction = carDto.YearOfProduction,
                CarRegistration = carDto.CarRegistration
            };

            _carRepositoryMock.Setup(repo => repo.AddCarAsync(It.IsAny<Car>())).Returns(Task.CompletedTask);

            // Act
            await _carService.AddCarAsync(carDto);

            // Assert
            _carRepositoryMock.Verify(repo => repo.AddCarAsync(It.Is<Car>(c =>
                c.ID == car.ID &&
                c.Brand == car.Brand &&
                c.Model == car.Model &&
                c.YearOfProduction == car.YearOfProduction &&
                c.CarRegistration == car.CarRegistration
            )), Times.Once);
        }

        [Test]
        public async Task UpdateCarAsync_UpdatesCar()
        {
            // Arrange
            var carDto = new CarDTO
            {
                ID = 1,
                Brand = "Toyota",
                Model = "Corolla",
                YearOfProduction = 2019,
                CarRegistration = "ABC123"
            };

            var car = _mapper.Map<Car>(carDto);
            _carRepositoryMock.Setup(repo => repo.UpdateCarAsync(car)).Returns(Task.CompletedTask);

            // Act
            await _carService.UpdateCarAsync(carDto);

            // Assert
            _carRepositoryMock.Verify(repo => repo.UpdateCarAsync(car), Times.Once);
        }

        [Test]
        public async Task DeleteCarAsync_DeletesCar()
        {
            // Arrange
            _carRepositoryMock.Setup(repo => repo.DeleteCarAsync(1)).Returns(Task.CompletedTask);

            // Act
            await _carService.DeleteCarAsync(1);

            // Assert
            _carRepositoryMock.Verify(repo => repo.DeleteCarAsync(1), Times.Once);
        }
    }
}
