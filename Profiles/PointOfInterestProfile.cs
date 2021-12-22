using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibAPI.Profiles
{
    public class PointOfInterestProfile : Profile 
    {
        public PointOfInterestProfile()
        {
            CreateMap<Models.PointOfInterest, DTO.PointOfInterestDto>();
        }
    }
}
