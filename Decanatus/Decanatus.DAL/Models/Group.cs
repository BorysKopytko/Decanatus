using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Group : Entity
    {
        [Required]
        [Display(Name = "Група")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public ICollection<LessonGroup> LessonGroups { get; set; }
    }
}
