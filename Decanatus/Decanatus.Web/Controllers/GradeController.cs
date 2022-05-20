using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Decanatus.Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public GradeController(IGradeService gradeService, UserManager<ApplicationUser> userManager)
        {
            _gradeService = gradeService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Адміністратор")]
        public IActionResult All()
        {
            return View(_gradeService.GetAllGrades());
        }

        [Authorize(Roles = "Студент")]
        public IActionResult Student()
        {
            return View(_gradeService.GetGradesByStudentId(_userManager.GetUserAsync(User).Result.PersonId));
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
        public async Task<IActionResult> CreateChooseSubject()
        {
            var gradeViewModel = _gradeService.CreateGradeViewModel(_userManager.GetUserAsync(User).Result.PersonId);

            return View(gradeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateChooseSubject")]
        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> CreateChooseSubjectPost(int subjectId, int lecturerId)
        {
            // TODO: Add validation

            var gradeViewModel = _gradeService.CreateGradeViewModel(lecturerId, subjectId);
            //_gradeService.AddGrades(gradeViewModel);

            return View(nameof(Create), gradeViewModel);
        }

        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> Create(GradeViewModel gradeViewModel)
        {
            return View(gradeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> CreatePost(GradeViewModel gradeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _gradeService.AddGrades(gradeViewModel);
                return RedirectToAction(nameof(Configure));
            }

            return View(gradeViewModel);
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Викладач")]
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
