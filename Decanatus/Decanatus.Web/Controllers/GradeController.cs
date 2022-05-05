using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
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

        public IActionResult All()
        {
            return View(_gradeService.GetAllGrades());
        }

        public IActionResult Student(int id = 1)
        {
            return View(_gradeService.GetGradesByStudentId(id));
        }

        public IActionResult Configure()
        {
            return View(_gradeService.GetAllGrades());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            await _gradeService.DeleteGradeAsync(id.Value);
            return RedirectToAction(nameof(Configure));
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Grade grade)
        //{
        //    if (grade == null)
        //    {
        //        return NotFound();
        //    }

        //    await _gradeService.AddGradeAsync(grade);
        //    return RedirectToAction(nameof(Configure));
        //}

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var grade = _gradeService.GetGradeById(id.Value);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Edit(Grade grade)
        {
            await _gradeService.UpdateGradeAsync(grade);
            return RedirectToAction(nameof(Configure));
        }
    }
}
