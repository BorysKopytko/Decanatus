using Decanatus.DAL.Abstractions;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.ViewModels
{
    public class LessonViewModel : Entity
    {
        public Lesson Lesson { get; set; }
        public List<SelectListItem> LessonNumbers { get; set; }
        public List<SelectListItem> Subject Subjects { get; set; }
    public List<SelectListItem> Audiences { get; set; }
    public List<SelectListItem> Lecturers { get; set; }
    public List<SelectListItem> Groups { get; set; }
}
}
