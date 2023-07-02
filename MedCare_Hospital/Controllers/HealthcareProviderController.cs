using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Services.IServices;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Controllers
{
    [Authorize(Roles ="Patient,Admin")]
    public class HealthcareProviderController : Controller
    {
        private readonly IHealthcareProviderService healthcareProviderService;

        public HealthcareProviderController(IHealthcareProviderService healthcareProviderService)
        {
            this.healthcareProviderService = healthcareProviderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var healthcareProviders = healthcareProviderService.GetAllHealthcareProviders();

            return View(healthcareProviders);
        }

        [HttpGet]
        public IActionResult GetHealthcareProviderById(int id)
        {
            var healthcareProvider = healthcareProviderService.GetHealthcareProviderById(id);

            if (healthcareProvider == null)
            {
                return NotFound();
            }

            return Ok(healthcareProvider);
        }

        [HttpGet]
        public IActionResult GetHealthcareProviderByName(string name)

        {
            var healthcareProvider = healthcareProviderService.GetHealthcareProviderByName(name);

            if (healthcareProvider == null)
            {
                return NotFound();
            }

            return Ok(healthcareProvider);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HealthcareProvider healthcareProvider)
        {
            healthcareProviderService.AddHealthcareProvider(healthcareProvider);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            var healthcareProviderDetails = healthcareProviderService.GetHealthcareProviderById(id);
            if (healthcareProviderDetails == null)
            {
                return View("NotFound");
            }

            return View(healthcareProviderDetails);
        }

        [HttpPost]
        public IActionResult Update(int id, HealthcareProvider healthcareProvider)
        {
            if (id != healthcareProvider.HealthcareProviderId)
            {
                return BadRequest();
            }

            healthcareProviderService.UpdateHealthcareProvider(healthcareProvider);

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var healthcareProviderDetails = healthcareProviderService.GetHealthcareProviderById(id);
            if (healthcareProviderDetails == null)
            {
                return View("NotFound");
            }

            return View(healthcareProviderDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var healthcareProviderDetails = healthcareProviderService.GetHealthcareProviderById(id);
            if (healthcareProviderDetails == null)
            {
                return View("NotFound");
            }

            healthcareProviderService.DeleteHealthcareProvider(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
