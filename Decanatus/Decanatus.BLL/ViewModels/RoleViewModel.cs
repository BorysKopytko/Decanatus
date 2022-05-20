using System.ComponentModel.DataAnnotations;

namespace Decanatus.BLL.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }


        [Display(Name = "Роль")]
        public string RoleName { get; set; }
    }
}
