using Decanatus.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тип заняття")]
        [EnumDataType(typeof(LessonType))]
        public LessonType LessonType { get; set; }

        [Required]
        [Display(Name = "Групи")]
        public ICollection<Group> Groups { get; set; }

        [Required]
        [Display(Name = "Чисельник / Знаменник")]
        [EnumDataType(typeof(LessonWeekType))]
        public LessonWeekType LessonWeekType { get; set; }

        [Required]
        [Display(Name = "День тижня")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        [Display(Name = "Номер пари")]
        public int LessonNumber { get; set; }

        [Required]
        [Display(Name = "Аудиторія")]
        public Audience Audience { get; set; }

        [Required]
        [Display(Name = "Викладачі")]
        public ICollection<Lecturer> Lecturers { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public Subject Subject { get; set; }
    }
}
