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

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            this.medicalRecordService = medicalRecordService;
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

        [HttpGet]
        public IActionResult GetMedicalRecordByPatientName(string name)

        {
            var medicalRecord = medicalRecordService.GetMedicalRecordByPatientName(name);

            if (medicalRecord == null)
            {
                return NotFound();
            }

            return Ok(medicalRecord);
        }

        public IActionResult Details(int id)
        {
            var medicalRecordDetials = medicalRecordService.GetMedicalRecordById(id);

            if (medicalRecordDetials == null)
            {
                return View("NotFound");
            }
            return View(medicalRecordDetials);
        }

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
