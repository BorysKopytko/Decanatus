using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Subject : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
