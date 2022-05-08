using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class Audience : Entity
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Аудиторія")]
        public string Name { get; set; }
    }
}
