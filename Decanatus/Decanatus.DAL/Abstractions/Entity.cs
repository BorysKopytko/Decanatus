using System.ComponentModel.DataAnnotations;

namespace Decanatus.DAL.Abstractions
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
