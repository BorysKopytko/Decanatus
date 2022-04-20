using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public enum Position
    {
        [Display(Name = "Асистент")]
        Assistant,
        [Display(Name = "Доцент")]
        Docent,
        [Display(Name = "Професор")]
        Professor,
    }

    public class Lecturer : Person
    {
        [Required]
        [Display(Name = "Посада")]
        [EnumDataType(typeof(Position))]
        public Position Position { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
