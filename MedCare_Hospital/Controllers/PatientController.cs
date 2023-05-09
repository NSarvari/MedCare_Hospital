using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHospital.Services.IServices;
using MyHospital_MVC.Models;

namespace MyHospital.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var patients = patientService.GetAllPatients();

            return View(patients);
        }

        [HttpGet]
        public IActionResult GetPatientById(int id)
        {
            var patient = patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet]
        public IActionResult GetPatientByName(string name)

        {
            var patient = patientService.GetPatientByName(name);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        public IActionResult Details(int id)
        {
            var patientDetials = patientService.GetPatientById(id);

            if (patientDetials == null)
            {
                return View("NotFound");
            }
            return View(patientDetials);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            patientService.AddPatient(patient);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var patientDetails = patientService.GetPatientById(id);
            if (patientDetails == null)
            {
                return View("NotFound");
            }

            return View(patientDetails);
        }

        [HttpPost]
        public IActionResult Update(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            patientService.UpdatePatient(patient);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var patientDetails = patientService.GetPatientById(id);
            if (patientDetails == null)
            {
                return View("NotFound");
            }

            return View(patientDetails);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var patientDetails = patientService.GetPatientById(id);
            if (patientDetails == null)
            {
                return View("NotFound");
            }

            patientService.DeletePatient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
