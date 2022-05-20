using Decanatus.BLL.Classes;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.Web.Controllers
{
    //[Authorize(Roles = "Адміністраторістратор")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScheduleController(IScheduleService scheduleService, UserManager<ApplicationUser> userManager)
        {
            _scheduleService = scheduleService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Configure()
        {
            var model = await _scheduleService.GetLessonsAsync();
            return View(model);
        }

        [Authorize(Roles = "Студент")]
        public async Task<IActionResult> StudentSchedule(EnumPeriodOfTime periodOfTime)
        {
            var model = await _scheduleService.GetStudentLessonsAsync(periodOfTime, _userManager.GetUserAsync(User).Result.PersonId);
            return View("StudentSchedule", model);
        }

        [Authorize(Roles = "Викладач")]
        public async Task<IActionResult> LecturerSchedule(EnumPeriodOfTime periodOfTime)
        {
            var model = await _scheduleService.GetLecturerLessonsAsync(periodOfTime, _userManager.GetUserAsync(User).Result.PersonId);
            return View("LecturerSchedule", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Адміністратор")]
        public IActionResult Add(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _scheduleService.AddNewLessonAsync(lesson);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //GET
       
        [Authorize(Roles = "Адміністратор")]
        public IActionResult Create()
        {
            var lessonViewModel = _scheduleService.CreateLessonViewModel();
            return View(lessonViewModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Create(LessonViewModel lessonViewModel)
        {
            await _scheduleService.CreateLessonAsync(lessonViewModel);
            return RedirectToAction(nameof(Configure));
        }

        //GET
        [Authorize(Roles = "Адміністратор")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var lessonViewModel = _scheduleService.GetLessonViewModel(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }

        //POST
        [HttpPost]
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> Edit(LessonViewModel lessonViewModel)
        {
            await _scheduleService.UpdateLessonAsync(lessonViewModel);
            return RedirectToAction(nameof(Configure));
        }

        //GET
        [Authorize(Roles = "Адміністратор")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var lessonViewModel = _scheduleService.GetLessonViewModel(id);

            if (lessonViewModel == null)
            {
                return NotFound();
            }

            return View(lessonViewModel);
        }


        //POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Адміністратор")]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            await _scheduleService.DeleteLessonAsync(id);
            return RedirectToAction(nameof(Configure));
        }
    }
}
