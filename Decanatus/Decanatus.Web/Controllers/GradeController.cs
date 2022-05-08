using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
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

        public IActionResult CreateChooseSubject(int lecturerId = 1)
        {
            var gradeViewModel = _gradeService.CreateGradeViewModel(lecturerId);

            return View(gradeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateChooseSubject")]
        public IActionResult CreateChooseSubjectPost(int subjectId, int lecturerId)
        {
            // TODO: Add validation

            var gradeViewModel = _gradeService.CreateGradeViewModel(lecturerId, subjectId);
            //_gradeService.AddGrades(gradeViewModel);

            return View(nameof(Create), gradeViewModel);
        }

        public IActionResult Create(GradeViewModel gradeViewModel)
        {
            return View(gradeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(GradeViewModel gradeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _gradeService.AddGrades(gradeViewModel);
                return RedirectToAction(nameof(Configure));
            }

            return View(gradeViewModel);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Grade grade)
        {
            if (ModelState.IsValid)
            {
                await _gradeService.UpdateGradeAsync(grade);
                return RedirectToAction(nameof(Configure));
            }

            return View(grade);
        }
    }
}
