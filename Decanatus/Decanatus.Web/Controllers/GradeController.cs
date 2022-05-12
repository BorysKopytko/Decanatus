using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Адміністратор")]
        public IActionResult All()
        {
            return View(_gradeService.GetAllGrades());
        }

        [Authorize(Roles = "Студент")]
        public IActionResult Student(int id = 1)
        {
            return View(_gradeService.GetGradesByStudentId(id));
        }

        [Authorize(Roles = "Викладач")]
        public IActionResult Configure()
        {
            return View(_gradeService.GetAllGrades());
        }

        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            await _gradeService.DeleteGradeAsync(id.Value);
            return RedirectToAction(nameof(Configure));
        }

        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> CreateChooseSubject(int id = 1) // lecturerId
        {
            var gradeViewModel = _gradeService.CreateGradeViewModel(id);

            return View(gradeViewModel);
        }

        [HttpPost]
        [ActionName("CreateChooseSubject")]
        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> CreateChooseSubjectPost(int SubjectId, int LecturerId)
        {
            var gradeViewModel = _gradeService.CreateGradeViewModel(LecturerId, SubjectId);
            //_gradeService.AddGrades(gradeViewModel);

            return View(nameof(Create), gradeViewModel);
        }

        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> Create(GradeViewModel gradeViewModel)
        {
            return View(gradeViewModel);
        }

        [HttpPost]
        [ActionName("Create")]
        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> CreatePost(GradeViewModel gradeViewModel)
        {
            await _gradeService.AddGrades(gradeViewModel);

            return RedirectToAction(nameof(Configure));
        }

        [Authorize(Roles = "Викладач")]
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
        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> Edit(Grade grade)
        {
            await _gradeService.UpdateGradeAsync(grade);
            return RedirectToAction(nameof(Configure));
        }
    }
}
