using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Models
{
    public class Audience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
