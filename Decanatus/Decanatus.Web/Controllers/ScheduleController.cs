using Decanatus.BLL.Services.Interfaces;
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

        public async Task<IActionResult> Setup()
        {
            var model = await _scheduleService.GetLessonsAsync();
            return View(model);
        }

        public async Task<IActionResult> StudentSchedule(string dayType)
        {
            var model = await _scheduleService.GetStudentLessonsAsync(dayType);
            return View(model);
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
    }
}
