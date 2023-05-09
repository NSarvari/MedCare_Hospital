using System.ComponentModel.DataAnnotations;

namespace MyHospital_MVC.Models
{
    public class HealthcareProvider
    {
        [Key]
        public int HealthcareProviderId { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public string Contact { get; set; }

        //Relations
        public List<Appointment> Appointments { get; set; }
        public List<PatientHealthcareProvider> PatientHealthcareProvider { get; set; }
    }
}
