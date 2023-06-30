using MedCare_Hospital.Data.Repositories.IRepositories;
using MedCare_Hospital.Data.ViewModels;
using MyHospital_MVC.Models;

namespace MedCare_Hospital.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PatientFeedback> GetAllFeedbacks()
        {
            var feedbackViewModels = from feedback in _context.Feedbacks
                                     join patient in _context.Patients on feedback.PatientId equals patient.PatientId
                                     select new PatientFeedback
                                     {
                                         FeedbackId = feedback.FeedbackId,
                                         FeedbackText = feedback.Text,
                                         PatientId = patient.PatientId,
                                         PatientName = patient.Name,
                                     };

            return feedbackViewModels.ToList();
        }

        public PatientFeedback GetFeedbackById(int feedbackId)
        {
            var feedbackViewModel = (from feedback in _context.Feedbacks
                                     join patient in _context.Patients on feedback.PatientId equals patient.PatientId
                                     where feedback.FeedbackId == feedbackId
                                     select new PatientFeedback
                                     {
                                         FeedbackId = feedback.FeedbackId,
                                         FeedbackText = feedback.Text,
                                         PatientId = patient.PatientId,
                                         PatientName = patient.Name,
                                     }).FirstOrDefault();

            return feedbackViewModel;
        }

        public void AddFeedback(PatientFeedback patientFeedback)
        {
            var feedback = new Feedback
            {
                Text = patientFeedback.FeedbackText,
                PatientId = patientFeedback.PatientId
            };

            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void UpdateFeedback(PatientFeedback patientFeedback)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.FeedbackId == patientFeedback.FeedbackId);

            if (feedback != null)
            {
                feedback.Text = patientFeedback.FeedbackText;
                feedback.PatientId = patientFeedback.PatientId;

                _context.SaveChanges();
            }
        }

        public void DeleteFeedback(int feedbackId)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.FeedbackId == feedbackId);

            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
            }
        }
    }
}
