using Decanatus.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Decanatus.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public IActionResult Setup()
        {
            var model = _scheduleService.GetLessonsAsync();
            return View(model);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }

            var lessonViewModel = _scheduleService.GetLessonViewModel(id); 

            if (lessonViewModel == null)
            {
                return NotFound();
            }
            
            return View(lessonViewModel);
        }
    }
}
