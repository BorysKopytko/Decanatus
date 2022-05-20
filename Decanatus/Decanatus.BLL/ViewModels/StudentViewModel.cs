using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Decanatus.BLL.ViewModels
{
    public class StudentViewModel : UserViewModel
    {
        [Required(ErrorMessage = "Введіть номер залікової книги")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер залікової книги")]
        public string GradebookNumber { get; set; }

        [Required(ErrorMessage = "Введіть номер наказу")]
        [Display(Name = "Номер наказу")]
        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "Введіть дату наказу")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата наказу")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Введіть дату закінчення навчання")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата закінчення навчання")]
        public DateTime GraduateDate { get; set; }

        [Required(ErrorMessage = "Виберіть групу")]
        [Display(Name = "Група")]
        public int GroupId { get; set; }


        [Required(ErrorMessage = "Виберіть форму навчання")]
        [EnumDataType(typeof(StudyingForm))]
        [Display(Name = "Форма навчання")]
        public StudyingForm StudyingForm { get; set; }

        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
    }
}
