using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var groupedByClass = await _context.Students
                .GroupBy(s => s.Class)
                .Select(g => new
                {
                    Class = g.Key,
                    AveragePresence = g.Average(s => s.PresenceCount),
                    AverageAbsence = g.Average(s => s.AbsenceCount),
                    AverageGrade = g.Average(s => s.Average)
                }).ToListAsync();

            var overallStats = new
            {
                AveragePresence = await _context.Students.AverageAsync(s => s.PresenceCount),
                AverageAbsence = await _context.Students.AverageAsync(s => s.AbsenceCount),
                AverageGrade = await _context.Students.AverageAsync(s => s.Average)
            };

            var passingFailingCounts = new
            {
                PassingCount = await _context.Students.CountAsync(s => s.Average >= 10),
                FailingCount = await _context.Students.CountAsync(s => s.Average < 10)
            };

            ViewBag.GroupedByClass = groupedByClass;
            ViewBag.OverallStats = overallStats;
            ViewBag.PassingFailingCounts = passingFailingCounts;

            return View();
        }
    }
}
