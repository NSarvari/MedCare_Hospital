using MyHospital_MVC.Models;

namespace MedCare_Hospital.Data.ViewModels
{
    public class PatientFeedback
    {
        public Feedback Feedback { get; set; }
        public int FeedbackId { get; set; }
        public string FeedbackText { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
