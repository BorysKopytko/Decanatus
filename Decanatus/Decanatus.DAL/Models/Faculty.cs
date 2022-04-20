using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Faculty : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public ICollection<Speciality> Specialities { get; set; }
    }
}
