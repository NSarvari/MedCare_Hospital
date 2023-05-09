using System.ComponentModel.DataAnnotations;

namespace MyHospital_MVC.Models
{
    public class MedicalRecord
    {

        [Key]
        public int MedicalRecordId { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Treatment { get; set; }
        [Required]
        public string Medication { get; set; }
        [Required]
        public string LabResult { get; set; }
        [Required]
        public string History { get; set; }

        //Relations
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
