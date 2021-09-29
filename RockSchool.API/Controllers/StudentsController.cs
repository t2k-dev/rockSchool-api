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
    public class StudentsController : ControllerBase
    {
        private readonly RockSchoolContext _context;

        public StudentsController(RockSchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var discepline = _context.Disceplines.FirstOrDefault();

            if (discepline == null)
            {
                return NotFound();
            }

            return Ok(discepline);
        }
    }
}
