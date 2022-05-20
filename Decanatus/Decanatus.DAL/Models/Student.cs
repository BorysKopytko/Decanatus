using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public enum StudyingForm
    {
        [Display(Name = "Денна")]
        FullTime,
        [Display(Name = "Заочна")]
        External,
    }

    public class Student : Person
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Номер залікової книги")]
        public string GradebookNumber { get; set; }

        [Required]
        [Display(Name = "Номер наказу")]
        public int OrderNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата наказу")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата закінчення навчання")]
        public DateTime GraduateDate { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        [Required]
        [EnumDataType(typeof(StudyingForm))]
        [Display(Name = "Форма навчання")]
        public StudyingForm StudyingForm { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
