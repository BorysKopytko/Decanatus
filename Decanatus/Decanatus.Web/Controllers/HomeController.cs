using System.Diagnostics;
using System.Linq.Expressions;
using Decanatus.BLL.Interfaces;
using Decanatus.BLL.Services.Interfaces;
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
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index(int id = 1)
        {
            var student = _homeService.GetStudent(id);
            var latestGrade = student.Grades.OrderByDescending(grade => grade.Date).FirstOrDefault();
            ViewData["LatestGradeAmount"] = latestGrade.Amount;
            ViewData["LatestGradeMaxAmount"] = latestGrade.MaxAmount;
            ViewData["LatestGradeSubject"] = latestGrade.Subject.Name;

            return View(student);
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