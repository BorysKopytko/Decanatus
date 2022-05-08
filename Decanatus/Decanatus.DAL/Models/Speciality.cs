using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Speciality : Entity
    {
        [Required]
        [Display(Name = "Спеціальність")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
