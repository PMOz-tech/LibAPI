using AutoMapper;
using LibAPI.DTO;
using LibAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibAPI.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {

        private readonly ICityInfoRepository cityInfoRepository;
        private readonly IMapper mapper;
        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            this.cityInfoRepository = cityInfoRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = cityInfoRepository.GetCities();

            return Ok(mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
        }


        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {

                return Ok(mapper.Map<CityDto>(city));

            }


            return Ok(mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }


        [HttpPost]
        public IActionResult CreateCity([FromBody] CityForCreationDTO city)
        {
            if (city.Name == city.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name"
                    );
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalCity = mapper.Map<Models.City>(city);
            cityInfoRepository.AddCity(finalCity);
            cityInfoRepository.Save();

            var createdCityToReturn = mapper.Map<DTO.CityDto>(finalCity);

            return CreatedAtRoute("GetCity", new { id = createdCityToReturn.Id }, createdCityToReturn);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityForUpdateDTO cityForUpdate)
        {
            if (cityForUpdate.Name == cityForUpdate.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name"
                    );
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!cityInfoRepository.CityExists(id))
            {
                return NotFound();
            }

            var cityGet = cityInfoRepository.GetCity(id, false);

            if (cityGet == null)
            {
                return NotFound();
            }

            mapper.Map(cityForUpdate, cityGet);



            cityInfoRepository.UpdateCity(cityGet);

            cityInfoRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            if(!cityInfoRepository.CityExists(id))
            {
                return NotFound();
            }

            var cityGet = cityInfoRepository.GetCity(id, false);
            if(cityGet == null)
            {
                return NotFound();
            }

            cityInfoRepository.DeleteCity(cityGet);
            cityInfoRepository.Save();
            return NoContent();

        }




    }
}
 