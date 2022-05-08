using System.ComponentModel.DataAnnotations;
using Decanatus.DAL.Abstractions;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Decanatus.BLL.ViewModels
{
    public class GradeViewModel : Entity
    {
        public List<SelectListItem> Subjects { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }

        [Required]
        [Display(Name = "Викладач")]
        public int LecturerId { get; set; }

        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Групи")]
        public IEnumerable<int> GroupsId { get; set; }

        [Required]
        [Display(Name = "Масимальна оцінка")]
        public int MaxAmount { get; set; }

        [Required]
        [Display(Name = "Тип оцінки")]
        public GradeType GradeType { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
