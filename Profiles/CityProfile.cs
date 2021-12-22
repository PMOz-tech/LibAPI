using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibAPI.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Models.City, DTO.CityWithoutPointsOfInterestDto>();
            CreateMap<Models.City, DTO.CityDto>();
            CreateMap<DTO.CityForCreationDTO, Models.City>();
            CreateMap<DTO.CityForUpdateDTO, Models.City>().ReverseMap();

            //CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
            //CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>()
            //    .ReverseMap();
        }
    }
}
