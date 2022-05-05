using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Faculty : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Факультет")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();
    }
}
