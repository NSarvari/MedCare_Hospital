using MyHospital_MVC.Models;

namespace MedCare_Hospital.Data.ViewModels
{
    public class PatientMedicalRecord
    {
        public Patient Patient { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
