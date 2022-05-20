using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Decanatus.BLL.ViewModels
{
    public class StudentViewModel : UserViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Номер залікової книги")]
        public string GradebookNumber { get; set; }

        [Required]
        [Display(Name = "Номер наказу")]
        public int OrderNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата наказу")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата закінчення навчання")]
        public DateTime GraduateDate { get; set; }

        [Display(Name = "Група")]
        public int GroupId { get; set; }


        [Required]
        [EnumDataType(typeof(StudyingForm))]
        [Display(Name = "Форма навчання")]
        public StudyingForm StudyingForm { get; set; }

        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
    }
}
