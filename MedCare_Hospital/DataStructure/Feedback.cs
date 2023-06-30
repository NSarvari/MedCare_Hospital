using System.ComponentModel.DataAnnotations;

namespace MyHospital_MVC.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Text { get; set; }

        //Relations
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
