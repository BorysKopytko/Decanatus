using Decanatus.BLL.Classes;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> Configure()
        {
            var model = await _scheduleService.GetLessonsAsync();
            return View(model);
        }

        public async Task<IActionResult> StudentSchedule(EnumPeriodOfTime periodOfTime)
        {
            var model = await _scheduleService.GetStudentLessonsAsync(periodOfTime, new Student
            {
                Id = 1,
                FirstName = "Святослав",
                LastName = "Боліщук",
                MiddleName = "Андрійович",
                //Sex = Abstractions.Sex.Male,
                BirthDate = DateTime.Parse("01.01.2021"),
                EmailAdress = "asdasd@gmail.com",
                MobilePhoneNumber = "393848543",
                GradebookNumber = "c214c12",
                OrderNumber = 123123,
                OrderDate = DateTime.Parse("01.01.2021"),
                GraduateDate = DateTime.Parse("01.01.2021"),
                StudyingForm = StudyingForm.FullTime,
                GroupId = 1,
            });
            return View("StudentSchedule", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult Create()
        {
            var lessonViewModel = _scheduleService.CreateLessonViewModel();
            return View(lessonViewModel);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel lessonViewModel)
        {
            await _scheduleService.CreateLessonAsync(lessonViewModel);
            return RedirectToAction(nameof(Configure));
        }

        //GET
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
        public async Task<IActionResult> Edit(LessonViewModel lessonViewModel)
        {
            await _scheduleService.UpdateLessonAsync(lessonViewModel);
            return RedirectToAction(nameof(Configure));
        }

        //GET
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
        public async Task<IActionResult> DeletePOST(int? id)
        {
            await _scheduleService.DeleteLessonAsync(id);
            return RedirectToAction(nameof(Configure));
        }
    }
}
