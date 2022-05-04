using Decanatus.DAL.Abstractions;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Тип заняття")]
        public LessonType LessonType { get; set; }
        [Display(Name = "Групи")]
        public IEnumerable <int> Groups { get; set; }
        [Display(Name = "Викладачі")]
        public IEnumerable <int> Lecturers { get; set; }
        [Display(Name = "Чисельник / Знаменник")]
        public LessonWeekType LessonWeekType { get; set; }
        [Display(Name = "День тижня")]
        public UkrainianDayOfWeek DayOfWeek { get; set; }
        [Display(Name = "Номер заняття")]
        public int LessonNumber { get; set; }
        [Display(Name = "Аудиторія")]
        public int Audience { get; set; }
        [Display(Name = "Предмет")]
        public int Subject { get; set; }

        public DateTime CreationDateTime { get; set; }


    }
}
