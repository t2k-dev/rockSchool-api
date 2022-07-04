using RockSchool.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockSchool.API.Services
{
    public class BaseService
    {
        protected readonly RockSchoolContext _context;

        public BaseService(RockSchoolContext context)
        {
            _context = context;
        }
    }
}
