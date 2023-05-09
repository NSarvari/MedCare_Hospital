using MyHospital_MVC.Models;

namespace MyHospital_MVC.Services.IServices
{
    public interface IPatientHealthcareProviderService
    {
        void AddPatientHealthcareProvider(PatientHealthcareProvider patientHealthcareProvider);
        void DeletePatientHealthcareProvider(int healthcareProviderId, int id);
        PatientHealthcareProvider GetPatientHealthcareProviderByPatientId(int patientId);
        List<PatientHealthcareProvider> GetAllPatientHealthcareProviders();
    }
}
