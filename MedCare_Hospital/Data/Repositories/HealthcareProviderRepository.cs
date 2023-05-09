using MedCare_Hospital.Data;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;

namespace MyHospital_MVC.DataAccess.Repositories
{
    public class HealthcareProviderRepository:IHealthcareProviderRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public HealthcareProviderRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public HealthcareProvider GetHealthcareProviderById(int id)
        {
            return _appDbContext.HealthcareProviders.FirstOrDefault(p => p.HealthcareProviderId == id);
        }

        public List<HealthcareProvider> GetAllHealthcareProviders()
        {
            return _appDbContext.HealthcareProviders.ToList();
        }

        //Get HealthcareProvider By name
        public List<HealthcareProvider> GetHealthcareProviderByName(string name)
        {
            return this._appDbContext.HealthcareProviders.Where(x => x.Name == name).ToList();
        }

        public void AddHealthcareProvider(HealthcareProvider healthcareProvider)
        {
            _appDbContext.HealthcareProviders.Add(healthcareProvider);
            _appDbContext.SaveChanges();
        }

        public void UpdateHealthcareProvider(HealthcareProvider healthcareProvider)
        {
            _appDbContext.HealthcareProviders.Update(healthcareProvider);
            _appDbContext.SaveChanges();
        }

        public void DeleteHealthcareProvider(int id)
        {
            var healthcareProvider = _appDbContext.HealthcareProviders.FirstOrDefault(hp => hp.HealthcareProviderId == id);
            if (healthcareProvider != null)
            {
                _appDbContext.HealthcareProviders.Remove(healthcareProvider);
                _appDbContext.SaveChanges();
            }
        }
    }
}
