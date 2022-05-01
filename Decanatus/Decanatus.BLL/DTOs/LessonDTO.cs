using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;
using Decanatus.DAL.Models;

namespace Decanatus.BLL.DTOs
{
    public class LessonDTO : Entity
    {
        [Required]
        [Display(Name = "Тип заняття")]
        [EnumDataType(typeof(LessonType))]
        public LessonType LessonType { get; set; }

        [Display(Name = "Групи")]
        public ICollection<Group> Groups { get; set; }

        [Required]
        [Display(Name = "Чисельник / Знаменник")]
        [EnumDataType(typeof(LessonWeekType))]
        public LessonWeekType LessonWeekType { get; set; }

        [Required]
        [Display(Name = "День тижня")]
        public DayOfWeek DayOfWeek { get; set; }

        [Display(Name = "Номер пари")]
        public LessonNumber LessonNumber { get; set; }

        public int LessonNumberId { get; set; }

        public int AudienceId { get; set; }

        [Display(Name = "Аудиторія")]
        public Audience Audience { get; set; }

        [Display(Name = "Викладачі")]
        public ICollection<Lecturer> Lecturers { get; set; }

        public int SubjectId { get; set; }

        [Display(Name = "Предмет")]
        public Subject Subject { get; set; }
    }
}
