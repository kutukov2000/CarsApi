using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using survey.Models;
using System.Diagnostics;

namespace survey.Controllers
{
    public class HomeController : Controller
    {
        private readonly SurveyDbContext _context;

        public HomeController(SurveyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Survey> surveys = _context.Surveys.ToList();

            return View(surveys);
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
