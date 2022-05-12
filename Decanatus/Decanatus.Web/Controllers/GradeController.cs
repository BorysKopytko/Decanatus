using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Decanatus.Web.Controllers
{
    [Authorize(Roles = "Викладач")]
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

        public async Task<IActionResult> CreateChooseSubject(int id = 1) // lecturerId
        {
            var gradeViewModel = _gradeService.CreateGradeViewModel(id);

            return View(gradeViewModel);
        }

        [HttpPost]
        [ActionName("CreateChooseSubject")]
        public async Task<IActionResult> CreateChooseSubjectPost(int SubjectId, int LecturerId)
        {
            var gradeViewModel = _gradeService.CreateGradeViewModel(LecturerId, SubjectId);
            //_gradeService.AddGrades(gradeViewModel);

            return View(nameof(Create), gradeViewModel);
        }

        public async Task<IActionResult> Create(GradeViewModel gradeViewModel)
        {
            return View(gradeViewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(GradeViewModel gradeViewModel)
        {
            await _gradeService.AddGrades(gradeViewModel);

            return RedirectToAction(nameof(Configure));
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
        public async Task<IActionResult> Edit(Grade grade)
        {
            await _gradeService.UpdateGradeAsync(grade);
            return RedirectToAction(nameof(Configure));
        }
    }
}
