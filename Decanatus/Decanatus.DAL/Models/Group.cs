using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Group
    {
        [Key]
        [Display(Name = "Назва групи")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Спеціальність")]
        public Speciality Speciality { get; set; }

        public ICollection <Student> Students { get; set; }
    }
}
