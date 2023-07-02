using MedCare_Hospital.Data;
using MedCare_Hospital.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Controllers
{
    [Authorize]
    public class MedicalRecordController:Controller
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly ApplicationDbContext context;

        public MedicalRecordController(IMedicalRecordService medicalRecordService, ApplicationDbContext context)
        {
            this.medicalRecordService = medicalRecordService;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var medicalRecords = medicalRecordService.GetAllMedicalRecords();

            return View(medicalRecords);
        }

        [HttpGet]
        public IActionResult GetMedicalRecordById(int id)
        {
            var medicalRecord = medicalRecordService.GetMedicalRecordById(id);

            if (medicalRecord == null)
            {
                return NotFound();
            }

            return Ok(medicalRecord);
        }

        [HttpGet,ActionName("GetName")]
        public IActionResult GetMedicalRecordByPatientName(string name)

        {
            var medicalRecord = medicalRecordService.GetMedicalRecordByPatientName(name);

            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        public IActionResult Details(int id)
        {
            // Retrieve the patient from the database
            var medicalRecord = context.MedicalRecords.Find(id);

            if (medicalRecord == null)
            {
                // Handle the case where the patient is not found
                return NotFound();
            }

            // Retrieve the medical record associated with the patient
            var patient = context.Patients.FirstOrDefault(mr => mr.MedicalRecord.MedicalRecordId == id);

            // Create the view model and populate it with the patient and medical record
            var viewModel = new PatientMedicalRecord
            {
                MedicalRecord = medicalRecord,
                Patient = patient
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin,HealthcareProvider")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MedicalRecord medicalRecord)
        {
            medicalRecordService.AddMedicalRecord(medicalRecord);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,HealthcareProvider")]
        public IActionResult Update(int id)
        {
            var medicalRecordDetails = medicalRecordService.GetMedicalRecordById(id);
            if (medicalRecordDetails == null)
            {
                return View("NotFound");
            }

            return View(medicalRecordDetails);
        }

        [HttpPost]
        public IActionResult Update(int id, MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.MedicalRecordId)
            {
                return BadRequest();
            }

            medicalRecordService.UpdateMedicalRecord(medicalRecord);

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin,HealthcareProvider")]
        public IActionResult Delete(int id)
        {
            var medicalRecordDetails = medicalRecordService.GetMedicalRecordById(id);
            if (medicalRecordDetails == null)
            {
                return View("NotFound");
            }

            return View(medicalRecordDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var medicalRecordDetails = medicalRecordService.GetMedicalRecordById(id);
            if (medicalRecordDetails == null)
            {
                return View("NotFound");
            }

            medicalRecordService.DeleteMedicalRecord(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
