using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Controllers
{
    [Authorize]
    public class PatientHealthcareProviderController : Controller
    {
        private readonly IPatientHealthcareProviderService patientHealthcareProviderService;

        public PatientHealthcareProviderController(IPatientHealthcareProviderService patientHealthcareProviderService)
        {
            this.patientHealthcareProviderService = patientHealthcareProviderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var patientHealthcareProviders = patientHealthcareProviderService.GetAllPatientHealthcareProviders();

            return View(patientHealthcareProviders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientHealthcareProvider patientHealthcareProvider)
        {
            patientHealthcareProviderService.AddPatientHealthcareProvider(patientHealthcareProvider);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var patientHealthcareProviderDetails = patientHealthcareProviderService.GetPatientHealthcareProviderByPatientId(id);
            if (patientHealthcareProviderDetails == null)
            {
                return View("NotFound");
            }

            return View(patientHealthcareProviderDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(PatientHealthcareProvider patientHealthcareProvider)
        {
            patientHealthcareProviderService.DeletePatientHealthcareProvider(patientHealthcareProvider.HealthcareProviderId,patientHealthcareProvider.PatientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
