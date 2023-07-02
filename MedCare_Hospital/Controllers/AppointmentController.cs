using MedCare_Hospital.Data;
using MedCare_Hospital.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHospital_MVC.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly ApplicationDbContext _appDbContext;


        public AppointmentController(IAppointmentService appointmentService, ApplicationDbContext aapDbContext)
        {
            this.appointmentService = appointmentService;
            this._appDbContext = aapDbContext;
        }

        [Authorize(Roles="Admin,HealthcareProvider")]
        [HttpGet]
        public IActionResult Index()
        {
            var appointments = appointmentService.GetAllAppointments();

            return View(appointments);
        }

        [Authorize(Roles="Patient")]
        public IActionResult ThankYou()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = appointmentService.GetAppointmentById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet]
        public IActionResult GetPatientAppointmentsById(int id)

        {
            var appointment = appointmentService.GetPatientAppointmentsById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet]
        public IActionResult GetHealthcareProviderAppointmentsById(int id)

        {
            var appointment = appointmentService.GetPatientAppointmentsById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        public IActionResult Details(int id)
        {
            // Retrieve the appointment from the data source based on the provided ID
            Appointment appointment = _appDbContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.HealthcareProvider)
                .FirstOrDefault(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            // Create a new instance of the PatientAppointment view model
            PatientAppointment patientAppointment = new PatientAppointment
            {
                Appointment = appointment,
                Patient = appointment.Patient,
                HealthcareProvider = appointment.HealthcareProvider
            };

            return View(patientAppointment);
        }

        [Authorize(Roles = "Admin,Patient")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            appointmentService.AddAppointment(appointment);
            if (User.IsInRole("Patient"))
            {
                return RedirectToAction(nameof(ThankYou));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            var appointmentDetails = appointmentService.GetAppointmentById(id);
            if (appointmentDetails == null)
            {
                return View("NotFound");
            }

            return View(appointmentDetails);
        }

        [HttpPost]
        public IActionResult Update(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            appointmentService.UpdateAppointment(appointment);

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var appointmentDetails = appointmentService.GetAppointmentById(id);
            if (appointmentDetails == null)
            {
                return View("NotFound");
            }

            return View(appointmentDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var appointmentDetails = appointmentService.GetAppointmentById(id);
            if (appointmentDetails == null)
            {
                return View("NotFound");
            }

            appointmentService.DeleteAppointment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
