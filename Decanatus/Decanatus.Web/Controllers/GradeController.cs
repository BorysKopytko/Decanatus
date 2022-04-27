using Decanatus.BLL.Interfaces;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Data;
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

        public IActionResult Index()
        {
            return View(_gradeService.GetAllGrades());
        }
    }
}
