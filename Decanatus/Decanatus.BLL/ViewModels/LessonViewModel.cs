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

        [Required(ErrorMessage = "Виберіть тип заняття")]
        [Display(Name = "Тип заняття")]
        public LessonType LessonType { get; set; }

        [Required(ErrorMessage = "Виберіть групи")]
        [Display(Name = "Групи")]
        public IEnumerable<int> Groups { get; set; }

        [Required(ErrorMessage = "Виберіть викладачів")]
        [Display(Name = "Викладачі")]
        public IEnumerable<int> Lecturers { get; set; }

        [Required(ErrorMessage = "Виберіть тип тижня")]
        [Display(Name = "Чисельник / Знаменник")]
        public LessonWeekType LessonWeekType { get; set; }

        [Required(ErrorMessage = "Виберіть день тижня")]
        [Display(Name = "День тижня")]
        public UkrainianDayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "Виберіть номер заняття")]
        [Display(Name = "Номер заняття")]
        public int LessonNumber { get; set; }

        [Required(ErrorMessage = "Виберіть аудиторію")]
        [Display(Name = "Аудиторія")]
        public int Audience { get; set; }

        [Required(ErrorMessage = "Виберіть предмет")]
        [Display(Name = "Предмет")]
        public int Subject { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
