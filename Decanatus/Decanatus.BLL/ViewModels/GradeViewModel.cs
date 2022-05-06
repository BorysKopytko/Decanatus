using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Decanatus.BLL.ViewModels
{
    public class GradeViewModel
    {
        public List<SelectListItem> Subjects { get; set; } = new List<SelectListItem>();

        public int SubjectId { get; set; }

        public int LecturerId { get; set; }

        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();

        public IEnumerable<int> GroupsId { get; set; }

        public int MaxAmount { get; set; }

        public GradeType GradeType { get; set; }

        public DateTime Date { get; set; }
    }
}
