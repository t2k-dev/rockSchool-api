using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockSchool.API.Entities
{
    public class RockSchoolContext : DbContext
    {
        public RockSchoolContext(DbContextOptions<RockSchoolContext> options) : base(options)
        {
        }

        public DbSet<Discepline> Disceplines { get; set; }



    }
}
