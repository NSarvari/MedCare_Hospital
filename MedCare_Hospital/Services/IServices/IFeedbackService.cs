using MedCare_Hospital.Data.ViewModels;
using MyHospital_MVC.Models;

namespace MedCare_Hospital.Services.IServices
{
    public interface IFeedbackService
    {
        IEnumerable<PatientFeedback> GetAllFeedbacks();
        PatientFeedback GetFeedbackById(int feedbackId);
        void AddFeedback(PatientFeedback patientFeedback1);
        void UpdateFeedback(PatientFeedback patientFeedback1);
        void DeleteFeedback(int feedbackId);
    }
}
