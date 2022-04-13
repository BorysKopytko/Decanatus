using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }

        
        [Display(Name = "Спеціальність")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        //[Required]
        //public string FacultyName { get; set; }



        public int FacultyId { get; set; }


        public Faculty Faculty { get; set; }

        public ICollection<Group> Groups { get; set; }

        
    }
}
