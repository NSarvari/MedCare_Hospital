using MyHospital.DataAccess.Repositories;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public void AddAppointment(Appointment appointment)
        {
            appointmentRepository.AddAppointment(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            appointmentRepository.UpdateAppointment(appointment);
        }

        public void DeleteAppointment(int id)
        {
            appointmentRepository.DeleteAppointment(id);
        }

        public Appointment GetAppointmentById(int id)
        {
            return appointmentRepository.GetAppointmentById(id);
        }

        public List<Appointment> GetPatientAppointmentsById(int id)
        {
            return appointmentRepository.GetPatientAppointmentsById(id);
        }

        public List<Appointment> GetHealthcareProviderAppointmentsById(int id)
        {
            return appointmentRepository.GetHealthcareProviderAppointmentsById(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentRepository.GetAllAppointments();
        }
    }
}
