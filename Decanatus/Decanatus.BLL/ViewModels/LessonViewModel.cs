using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Decanatus.BLL.ViewModels
{
    public class LessonViewModel : Entity
    {
        public List<SelectListItem> AllLessonNumbers { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> AllSubjects { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> AllAudiences { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> AllLecturers { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> AllGroups { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Тип заняття")]
        public LessonType LessonType { get; set; }

        [Required]
        [Display(Name = "Групи")]
        public IEnumerable<int> Groups { get; set; }

        [Required]
        [Display(Name = "Викладачі")]
        public IEnumerable<int> Lecturers { get; set; }

        [Required]
        [Display(Name = "Чисельник / Знаменник")]
        public LessonWeekType LessonWeekType { get; set; }

        [Required]
        [Display(Name = "День тижня")]
        public UkrainianDayOfWeek DayOfWeek { get; set; }

        [Required]
        [Display(Name = "Номер заняття")]
        public int LessonNumber { get; set; }

        [Required]
        [Display(Name = "Аудиторія")]
        public int Audience { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public int Subject { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
