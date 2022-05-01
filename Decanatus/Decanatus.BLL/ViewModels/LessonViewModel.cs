using Decanatus.DAL.Abstractions;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.ViewModels
{
    public class LessonViewModel : Entity
    {
        public List<SelectListItem> AllLessonNumbers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AllSubjects { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AllAudiences { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AllLecturers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> AllGroups { get; set; } = new List<SelectListItem>();

        public LessonType LessonType { get; set; }
        public IEnumerable <int> Groups { get; set; }
        public IEnumerable <int> Lecturers { get; set; }
        public LessonWeekType LessonWeekType { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public int Audience { get; set; }
        public int Subject { get; set; }


    }
}
