using AutoMapper;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;

namespace Labs2024_Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapowanie dla Car
            CreateMap<Car, CarDTO>();
            CreateMap<CarDTO, Car>();

            // Mapowanie dla User
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Rental, RentalDTO>();
            CreateMap<RentalDTO, Rental>();
        }
    }
}
