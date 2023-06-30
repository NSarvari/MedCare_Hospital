using MedCare_Hospital.Data.ViewModels;
using MyHospital_MVC.Models;

namespace MedCare_Hospital.Data.Repositories.IRepositories
{
    public interface IFeedbackRepository
    {
        IEnumerable<PatientFeedback> GetAllFeedbacks();
        PatientFeedback GetFeedbackById(int feedbackId);
        void AddFeedback(PatientFeedback patientFeedback);
        void UpdateFeedback(PatientFeedback patientFeedback);
        void DeleteFeedback(int feedbackId);
    }
}
