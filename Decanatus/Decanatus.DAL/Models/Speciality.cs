using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Speciality
    {
        [Key]
        [Display(Name = "Спеціальність")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Факультет")]
        public Faculty Faculty { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
