using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Decanatus.BLL.ViewModels
{
    public class LecturerViewModel: UserViewModel
    {
        [Required]
        [Display(Name = "Посада")]
        [EnumDataType(typeof(Position))]
        public Position Position { get; set; }
    }
}
