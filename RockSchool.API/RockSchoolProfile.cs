﻿using AutoMapper;
using RockSchool.API.Entities;
using RockSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockSchool.API
{
    public class RockSchoolProfile: Profile
    {
        public RockSchoolProfile()
        {
            CreateMap<Discipline, DisciplineDto>()
                .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.DisciplineName, map => map.MapFrom(s => s.DisciplineName))
                .ForMember(d => d.IsActive, map => map.MapFrom(s => s.IsActive));

            CreateMap<AddStudentDto, Student>();

            CreateMap<AddScheduleDto, Schedule>();
        }
    }
}
