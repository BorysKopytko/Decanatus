using Decanatus.DAL.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Lecturer: Person
    {

        [Required]
        [Display(Name = "Посада")]
        [EnumDataType(typeof(Position))]
        public Position Position { get; set; }

        public ICollection<Lesson> Lessons { get; set; }    
    }

    public enum Position
    {
        [Display(Name = "Асистент")]
        Assistant,
        [Display(Name = "Доцент")]
        Docent,
        [Display(Name = "Професор")]
        Professor
    }
}
