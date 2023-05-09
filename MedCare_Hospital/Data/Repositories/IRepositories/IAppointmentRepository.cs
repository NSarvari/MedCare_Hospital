using MyHospital_MVC.Models;

namespace MyHospital_MVC.DataAccess.Repositories.IRepositories
{
    public interface IAppointmentRepository
    {
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        Appointment GetAppointmentById(int id);
        List<Appointment> GetPatientAppointmentsById(int id);
        List<Appointment> GetHealthcareProviderAppointmentsById(int id);
        List<Appointment> GetAllAppointments();
    }
}
