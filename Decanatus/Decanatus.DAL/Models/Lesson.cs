using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public enum LessonType
    {
        [Display(Name = "Лекція")]
        Lecture,
        [Display(Name = "Практична робота")]
        Laboratory,
    }

    public enum LessonWeekType
    {
        [Display(Name = "Чисельник")]
        Numerator,
        [Display(Name = "Знаменник")]
        Denominator,
        [Display(Name = "Кожен тиждень")]
        Both,
    }

    public enum UkrainianDayOfWeek
    {
        [Display(Name ="Понеділок")]
        Monday,
        [Display(Name ="Вівторок")]
        Tuesday,
        [Display(Name ="Середа")]
        Wednesday,
        [Display(Name ="Четвер")]
        Thursday,
        [Display(Name ="П'ятниця")]
        Friday,
        [Display(Name ="Субота")]
        Saturday,
        [Display(Name ="Неділя")]
        Sunday
    }

    public class Lesson : Entity
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
        [Display(Name = "День тижня модал")]
        public UkrainianDayOfWeek DayOfWeek { get; set; }

        [Required]
        [Display(Name = "День тижня")]
        public DayOfWeek DayOfWeekTime { get; set; }

        [Display(Name = "Номер пари")]
        public LessonNumber LessonNumber { get; set; }

        public int LessonNumberId { get; set; }

        public int AudienceId { get; set; }

        [Display(Name ="Аудиторія")]
        public Audience Audience { get; set; }

        [Display(Name = "Викладачі")]
        public ICollection<Lecturer> Lecturers { get; set; }

        public int SubjectId { get; set; }

        [Display(Name = "Предмет")]
        public Subject Subject { get; set; }

        public ICollection<LessonGroup> LessonGroups { get; set; }
        public ICollection<LessonLecturer> LessonLecturers { get; set; }

        public DateTime CreationDateTime { get; set; } = DateTime.Now;

    }
}
