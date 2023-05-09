using MyHospital_MVC.Models;

namespace MyHospital_MVC.Services.IServices
{
    public interface IHealthcareProviderService
    {
        void AddHealthcareProvider(HealthcareProvider healthcareProvider);
        void UpdateHealthcareProvider(HealthcareProvider healthcareProvider);
        void DeleteHealthcareProvider(int id);
        HealthcareProvider GetHealthcareProviderById(int id);
        List<HealthcareProvider> GetAllHealthcareProviders();
        HealthcareProvider GetHealthcareProviderByName(string name);
    }
}
