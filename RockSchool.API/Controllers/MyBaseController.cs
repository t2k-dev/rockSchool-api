using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockSchool.API.Entities;

namespace RockSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyBaseController : ControllerBase
    {
        protected readonly RockSchoolContext _context;
        protected readonly IMapper _mapper;

        public MyBaseController(RockSchoolContext rockSchoolContext, IMapper mapper)
        {
            _context = rockSchoolContext;
            _mapper = mapper;
        }
    }
}
