using System.ComponentModel.DataAnnotations;

namespace MyHospital_MVC.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Question { get; set; }
    }
}
