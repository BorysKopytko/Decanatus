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
        [Display(Name = "Максимальна оцінка")]
        public int MaxAmount { get; set; }

        [Display(Name = "Оцінка")]
        public int? Amount { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Display(Name = "Тип оцінки")]
        [EnumDataType(typeof(GradeType))]
        public GradeType GradeType { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; } = DateTime.Now;

        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
