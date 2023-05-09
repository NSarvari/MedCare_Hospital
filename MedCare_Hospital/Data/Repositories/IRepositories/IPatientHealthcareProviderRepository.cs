using MyHospital_MVC.Models;

namespace MyHospital_MVC.DataAccess.Repositories.IRepositories
{
    public interface IPatientHealthcareProviderRepository
    {
        void AddPatientHealthcareProvider(PatientHealthcareProvider appointment);
        void DeletePatientHealthcareProvider(int healthcareProviderId, int id);
        PatientHealthcareProvider GetPatientHealthcareProviderByPatientId(int patientId);
        List<PatientHealthcareProvider> GetAllPatientHealthcareProviders();
    }
}
