using System.ComponentModel.DataAnnotations;

namespace MyHospital_MVC.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Contact { get; set; }

        //Relations
        public List<PatientHealthcareProvider> PatientHealthcareProvider { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
