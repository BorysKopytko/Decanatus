using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Subject : Entity
    {
        [Required]
        [Display(Name = "Предмет")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
