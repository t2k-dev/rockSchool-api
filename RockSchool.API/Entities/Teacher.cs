using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockSchool.API.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public long Phone { get; set; }
        public ICollection<Discipline> Disciplines { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
