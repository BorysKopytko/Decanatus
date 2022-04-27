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
        public IActionResult Index()
        {
            var model = _scheduleService.GetLessonsAsync();
            return View(model);
        }
    }
}
