using System;
using System.Collections.Generic;
using AutoMapper;
using CarService.Data;
using CarService.Dtos;
using CarService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController  : ControllerBase
    {
        private readonly ICarRepo _repository;
        private readonly IMapper _mapper;

        public CarsController(ICarRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting cars....");

            var carItem = _repository.GetAllCars();

            return Ok(_mapper.Map<IEnumerable<CarReadDto>>(carItem));
        }

    
        [HttpGet("{id}", Name = "GetCarById")]
        public ActionResult<CarReadDto> GetCarById(int id)
        {
            var CarItem = _repository.GetCarById(id);
            if (CarItem != null)
            {
                return Ok(_mapper.Map<CarReadDto>(CarItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CarReadDto> CreateCar(CarCreateDto carCreateDto)
        {
            var carModel = _mapper.Map<Car>(carCreateDto);
            _repository.CreateCar(carModel);
            _repository.SaveChanges();

            var carReadDto = _mapper.Map<CarReadDto>(carModel);

            return CreatedAtRoute(nameof(GetCarById), new { carReadDto.Id}, carReadDto);
        }
    }
}