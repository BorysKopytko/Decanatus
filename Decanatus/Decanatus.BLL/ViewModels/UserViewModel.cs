using Decanatus.DAL.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.ViewModels
{
    public abstract class UserViewModel: Person
    {

        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Гасло")]
        public string Password { get; set; }

        [Display(Name = "Підтвердження гасла")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
        public List<SelectListItem> ApplicationRoles { get; set; } = new List<SelectListItem>();
        [Display(Name = "Роль")]
        public string ApplicationRoleId { get; set; }
    }
}
