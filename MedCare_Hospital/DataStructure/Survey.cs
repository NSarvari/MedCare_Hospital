using System.ComponentModel.DataAnnotations;

namespace MedCare_Hospital.DataStructure
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Have you traveled outside the country in the last 14 days?")]
        public string TraveledOutsideCountry { get; set; }

        [Required]
        [Display(Name = "Have you been in close contact with someone who has tested positive for COVID-19 in the past 14 days?")]
        public string ContactWithCovid { get; set; }

        [Required]
        [Display(Name = "Do you have any of the following symptoms: fever, cough, shortness of breath, sore throat, muscle aches, chills, or new loss of taste or smell?")]
        public string HasSymptoms { get; set; }

        [Required]
        [Display(Name = "Have you tested positive for COVID-19 in the last 14 days?")]
        public string TestedPositive { get; set; }

        [Required]
        [Display(Name = "Have you received a COVID-19 vaccine?")]
        public string ReceivedVaccine { get; set; }

        [Required]
        [Display(Name = "Are you willing to participate in contact tracing if needed?")]
        public string ParticipateInContactTracing { get; set; }

        [Required]
        [Display(Name = "Do you have any additional comments or concerns?")]
        public string Comments { get; set; }
    }
}
