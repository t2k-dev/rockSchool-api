using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RockSchool.API.Entities;
using RockSchool.API.Models;

namespace RockSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : MyBaseController
    {
        public ScheduleController(RockSchoolContext rockSchoolContext, IMapper mapper)
            : base(rockSchoolContext, mapper)
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            var schedules = _context.Schedules.ToList();

            if (schedules == null)
            {
                return NotFound();
            }

            return Ok(schedules);
        }

        [HttpPost]
        public ActionResult Post(AddScheduleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSchedule = _mapper.Map<Schedule>(model);

            _context.Schedules.Add(newSchedule);
            _context.SaveChanges();

            return Ok();
        }
    }
}
