using System.ComponentModel.DataAnnotations;

namespace MyHospital_MVC.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string AppointmentDate { get; set; }
        [Required]
        public string Reason { get; set; }

        //Relations
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int HealthcareProviderId { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
    }
}
