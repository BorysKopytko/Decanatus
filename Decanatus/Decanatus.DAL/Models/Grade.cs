using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public enum GradeType
    {
        [Display(Name = "Лекція")]
        Lecture,
        [Display(Name = "Практична робота")]
        Practice,
        [Display(Name = "Лабораторна робота")]
        Laboratory,
        [Display(Name = "Модуль")]
        Module,
        [Display(Name = "Іспит")]
        Exam,
    }

    public class Grade : Entity
    {
        [Required]
        [Range(0, 100)]
        [Display(Name = "Максимальна оцінка")]
        public int MaxAmount { get; set; }

        [Required]
        [Display(Name = "Оцінка")]
        [Range(0, 100)]
        public int Amount { get; set; }

        public int StudentId { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        [Display(Name = "Тип оцінки")]
        [EnumDataType(typeof(GradeType))]
        public GradeType GradeType { get; set; }

        public int SubjectId { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
