using MedCare_Hospital.Data;
using MedCare_Hospital.DataStructure;
using Microsoft.AspNetCore.Mvc;

namespace MedCare_Hospital.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurveyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ThankYou));
            }

            return View(survey);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }

}
