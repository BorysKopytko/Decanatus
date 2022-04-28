using Decanatus.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Decanatus.Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public IActionResult AllGrades()
        {
            return View("AllGrades", _gradeService.GetAllGrades());
        }

        public IActionResult GradesByStudentId(int id = 1)
        {
            return View("StudentGrades", _gradeService.GetGradesByStudentId(id));
        }
    }
}
