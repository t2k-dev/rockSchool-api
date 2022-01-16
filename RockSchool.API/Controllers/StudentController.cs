using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockSchool.API.Entities;

namespace RockSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly RockSchoolContext _context;

        public StudentController(RockSchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var discepline = _context.Disciplines.FirstOrDefault();

            if (discepline == null)
            {
                return NotFound();
            }

            return Ok(discepline);
        }
    }
}
