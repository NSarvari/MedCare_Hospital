using MedCare_Hospital.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Index()
        {
            var appointments = appointmentService.GetAllAppointments();

            return View(appointments);
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
            var appointmentDetials = appointmentService.GetAppointmentById(id);

            if (appointmentDetials == null)
            {
                return View("NotFound");
            }
            return View(appointmentDetials);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            //appointment = _appDbContext.Appointments.Where(x => x.Date == date).FirstOrDefault();

            //if (appointment != null)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //}
            appointmentService.AddAppointment(appointment);
            return RedirectToAction(nameof(Index));
        }

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
