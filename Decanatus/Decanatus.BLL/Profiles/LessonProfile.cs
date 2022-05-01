using AutoMapper;
using Decanatus.BLL.DTOs;
using Decanatus.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Lesson, LessonDTO>();
            CreateMap<LessonDTO, Lesson>();
        }
    }
}
