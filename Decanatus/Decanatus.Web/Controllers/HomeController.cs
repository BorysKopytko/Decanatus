using Decanatus.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Decanatus.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore.Query;
using Decanatus.BLL.Interfaces;
using System.Linq.Expressions;

namespace Decanatus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly ILessonRepository _lesson;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, ILessonRepository lesson)
        {
            _logger = logger;
            _dbContext = dbContext;
            _lesson = lesson;
        }

        private Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> GetInclude()
        {
            Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> expr = x => x.Include(i => i.Audience).Include(c => c.Subject).Include(a => a.Lecturers);
            return expr;
        }

        private Expression<Func<Lesson, Lesson>> GetSelector()
        {
            Expression<Func<Lesson, Lesson>> expr = x => x;
            return expr;
        }

        public IActionResult Index()
        {
            var include = GetInclude();
            //var select = GetSelector();
            var lessons = _lesson.Includer(include);


            return View(lessons.Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}