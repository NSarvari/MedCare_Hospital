using MyHospital.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Services
{
    public class HealthcareProviderService: IHealthcareProviderService
    {
        private readonly IHealthcareProviderRepository healthcareProviderRepository;

        public HealthcareProviderService(IHealthcareProviderRepository healthcareProviderRepository)
        {
            this.healthcareProviderRepository = healthcareProviderRepository;
        }

        public void AddHealthcareProvider(HealthcareProvider healthcareProvider)
        {
            healthcareProviderRepository.AddHealthcareProvider(healthcareProvider);
        }

        public void UpdateHealthcareProvider(HealthcareProvider healthcareProvider)
        {
            healthcareProviderRepository.UpdateHealthcareProvider(healthcareProvider);
        }

        public void DeleteHealthcareProvider(int id)
        {
            healthcareProviderRepository.DeleteHealthcareProvider(id);
        }

        public HealthcareProvider GetHealthcareProviderById(int id)
        {
            return healthcareProviderRepository.GetHealthcareProviderById(id);
        }

        public List<HealthcareProvider> GetAllHealthcareProviders()
        {
            return healthcareProviderRepository.GetAllHealthcareProviders();
        }

        public HealthcareProvider GetHealthcareProviderByName(string name)
        {
            return healthcareProviderRepository.GetAllHealthcareProviders()
                .FirstOrDefault(p => p.Name == name);
        }
    }
}
