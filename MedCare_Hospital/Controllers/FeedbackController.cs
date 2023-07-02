using MedCare_Hospital.Data;
using MedCare_Hospital.Data.ViewModels;
using MedCare_Hospital.Services;
using MedCare_Hospital.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHospital.Services.IServices;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services;
using MyHospital_MVC.Services.IServices;

namespace MedCare_Hospital.Controllers
{
    [Authorize(Roles="Admin,Patient")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;
        private readonly ApplicationDbContext _context;

        public FeedbackController(IFeedbackService feedbackService, ApplicationDbContext context)
        {
            this.feedbackService = feedbackService;
            _context = context;
        }

        // GET: Feedback
        public IActionResult Index()
        {
            var feedbacks = from feedback in _context.Feedbacks
                            join patient in _context.Patients on feedback.PatientId equals patient.PatientId
                            select new PatientFeedback
                            {
                                Feedback = new Feedback
                                {
                                    FeedbackId = feedback.FeedbackId,
                                    Text = feedback.Text
                                },
                                Patient = new Patient
                                {
                                    PatientId = patient.PatientId,
                                    Name = patient.Name
                                }
                            };


            // return feedbackViewModels.ToList();
            return View(feedbacks);
        }

        // GET: Feedback/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        public IActionResult Create(PatientFeedback feedback)
        {
            feedbackService.AddFeedback(feedback);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        // GET: Feedback/Edit/5
        public IActionResult Update(int id)
        {
            var feedbackViewModel = feedbackService.GetFeedbackById(id);
            if (feedbackViewModel == null)
            {
                return NotFound();
            }

            return View(feedbackViewModel);
        }

        // POST: Feedback/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, PatientFeedback patientFeedback)
        {
            if (id != patientFeedback.Feedback.FeedbackId)
            {
                return NotFound();
            }

            feedbackService.UpdateFeedback(patientFeedback);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        // GET: Feedback/Delete/5
        public IActionResult Delete(int id)
        {
            var feedback = feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var feedback = feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return View("NotFound");
            }

            feedbackService.DeleteFeedback(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
