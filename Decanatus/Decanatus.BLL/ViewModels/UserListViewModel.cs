using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.ViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        [Display(Name ="Електронна пошта")]
        public string Email { get; set; }
        [Display(Name = "Роль")]
        public string RoleName { get; set; }
    }
}
