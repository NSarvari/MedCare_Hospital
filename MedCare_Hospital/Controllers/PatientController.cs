using MedCare_Hospital.Data;
using MedCare_Hospital.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHospital.Services.IServices;
using MyHospital_MVC.Models;

namespace MyHospital.Controllers
{
    [Authorize(Roles="Admin,HealthcareProvider")]
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;
        private readonly ApplicationDbContext context;

        public PatientController(IPatientService patientService, ApplicationDbContext context)
        {
            this.patientService = patientService;
            this.context = context;
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
            // Retrieve the patient from the database
            var patient = context.Patients.Find(id);

            if (patient == null)
            {
                // Handle the case where the patient is not found
                return NotFound();
            }

            // Retrieve the medical record associated with the patient
            var medicalRecord = context.MedicalRecords.FirstOrDefault(mr => mr.PatientId == id);

            // Create the view model and populate it with the patient and medical record
            var viewModel = new PatientMedicalRecord
            {
                Patient = patient,
                MedicalRecord = medicalRecord
            };

            return View(viewModel);
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
