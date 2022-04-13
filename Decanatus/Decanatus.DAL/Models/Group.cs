using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Назва групи")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        public int SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public ICollection <Student> Students { get; set; }
        public ICollection <Lesson> Lessons { get; set; }
    }
}
