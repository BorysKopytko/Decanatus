using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тип заняття")]
        [EnumDataType(typeof(LessonType))]
        public LessonType LessonType { get; set; }

        [Required]
        public ICollection<Group> Groups { get; set; }

        [Required]
        [Display(Name = "Чисельник / Знаменник")]
        [EnumDataType(typeof(LessonWeekType))]
        public LessonWeekType LessonWeekType { get; set; }

        [Required]
        [Display(Name = "День тижня")]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        [Range(1, 7)]
        [Display(Name = "Номер пари")]
        public int LessonNumber { get; set; }

        public int AudienceId { get; set; }
        public Audience Audience { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }

    public enum LessonType
    {
        [Display(Name = "Лекція")]
        Lecture,
        [Display(Name = "Лабораторна робота")]
        Laboratory

    }

    public enum LessonWeekType
    {
        [Display(Name = "Чисельник")]
        Numerator,
        [Display(Name = "Знаменник")]
        Denominator,
        [Display(Name = "Кожен тиждень")]
        Both
    }
}
