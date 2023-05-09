using MyHospital_MVC.Models;

namespace MyHospital_MVC.DataAccess.Repositories.IRepositories
{
    public interface IHealthcareProviderRepository
    {
        void AddHealthcareProvider(HealthcareProvider healthcareProvider);
        void UpdateHealthcareProvider(HealthcareProvider healthcareProvider);
        void DeleteHealthcareProvider(int id);
        HealthcareProvider GetHealthcareProviderById(int id);
        List<HealthcareProvider> GetHealthcareProviderByName(string name);
        List<HealthcareProvider> GetAllHealthcareProviders();
    }
}
