namespace MyHospital_MVC.Models
{
    public class PatientHealthcareProvider
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int HealthcareProviderId { get; set; }
        public HealthcareProvider HealthcareProvider { get; set; }
    }
}
