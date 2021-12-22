using AutoMapper;
using LibAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibAPI.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointOfInterestController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRespository;
        private readonly IMapper _mapper;
        public PointOfInterestController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRespository = cityInfoRepository;
            _mapper = mapper;
        }
       
    }
}
