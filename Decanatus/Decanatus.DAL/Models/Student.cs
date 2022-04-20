using Decanatus.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Student : Person
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Номер залікової книги")]
        public int GradebookNumber { get; set; }

        [Required]
        [Display(Name = "Номер наказу")]
        public int OrderNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Дата наказу")]
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

    public enum StudyingForm
    {
        [Display(Name = "Денна")]
        FullTime,
        [Display(Name = "Заочна")]
        External
    }
}
