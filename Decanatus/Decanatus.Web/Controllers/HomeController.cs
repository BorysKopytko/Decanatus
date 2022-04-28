using System.Diagnostics;
using System.Linq.Expressions;
using Decanatus.BLL.Interfaces;
using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILessonRepository _lesson;

        public HomeController(ILessonRepository lesson)
        {
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
            //var include = GetInclude();
            //var select = GetSelector();
            //var lessons = _lesson.Includer(include);

            //return View(lessons.Result);
            return View();
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