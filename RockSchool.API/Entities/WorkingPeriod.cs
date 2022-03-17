using System;

namespace RockSchool.API.Entities
{
    public class WorkingPeriod
    {
        public int WorkingPeriodId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public short WeekDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
