using MedCare_Hospital.Data.Repositories;
using MedCare_Hospital.Data.Repositories.IRepositories;
using MedCare_Hospital.Data.ViewModels;
using MedCare_Hospital.Services.IServices;
using MyHospital.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;

namespace MedCare_Hospital.Services
{
    public class FeedbackService : IFeedbackService
    {

        private readonly IFeedbackRepository feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public IEnumerable<PatientFeedback> GetAllFeedbacks()
        {
            return feedbackRepository.GetAllFeedbacks();
        }

        public PatientFeedback GetFeedbackById(int feedbackId)
        {
            return feedbackRepository.GetFeedbackById(feedbackId);
        }

        public void AddFeedback(PatientFeedback patientFeedback)
        {
            feedbackRepository.AddFeedback(patientFeedback);
        }

        public void UpdateFeedback(PatientFeedback feedback)
        {
            feedbackRepository.UpdateFeedback(feedback);
        }

        public void DeleteFeedback(int feedbackId)
        {
            feedbackRepository.DeleteFeedback(feedbackId);
        }
    }
}
