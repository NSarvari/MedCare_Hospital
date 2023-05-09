using MyHospital.DataAccess.Repositories;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Services
{
    public class PatientHealthcareProviderService : IPatientHealthcareProviderService
    {
        private readonly IPatientHealthcareProviderRepository patientHealthcareProviderRepository;

        public PatientHealthcareProviderService(IPatientHealthcareProviderRepository patientHealthcareProviderRepository)
        {
            this.patientHealthcareProviderRepository = patientHealthcareProviderRepository;
        }

        public void AddPatientHealthcareProvider(PatientHealthcareProvider patientHealthcareProvider)
        {
            patientHealthcareProviderRepository.AddPatientHealthcareProvider(patientHealthcareProvider);
        }

        public void DeletePatientHealthcareProvider(int healthcareProviderId, int id)
        {
            patientHealthcareProviderRepository.DeletePatientHealthcareProvider(healthcareProviderId,id);
        }

        public List<PatientHealthcareProvider> GetAllPatientHealthcareProviders()
        {
            return patientHealthcareProviderRepository.GetAllPatientHealthcareProviders();
        }

        public PatientHealthcareProvider GetPatientHealthcareProviderByPatientId(int patientId)
        {
            return patientHealthcareProviderRepository.GetPatientHealthcareProviderByPatientId(patientId);
        }
    }
}