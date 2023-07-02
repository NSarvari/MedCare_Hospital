using MyHospital_MVC.Models;

namespace MedCare_Hospital.Data.ViewModels
{
    public class PatientAppointment
    {
        public Appointment Appointment { get; set; }     
        public Patient Patient { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
    }
}
