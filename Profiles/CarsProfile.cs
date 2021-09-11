using AutoMapper;
using CarService.Models;
using CarService.Dtos;

namespace CarService.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarReadDto>();
            CreateMap<CarCreateDto, Car>();
        }
    }
}