using MedCare_Hospital.Data;
using Microsoft.EntityFrameworkCore;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;

namespace MyHospital_MVC.DataAccess.Repositories
{
    public class PatientHealthcareProviderRepository : IPatientHealthcareProviderRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public PatientHealthcareProviderRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<PatientHealthcareProvider> GetAllPatientHealthcareProviders()
        {
            return _appDbContext.PatientHealthcareProviders.ToList();
        }

        public void AddPatientHealthcareProvider(PatientHealthcareProvider patientHealthcareProvider)
        {
            _appDbContext.PatientHealthcareProviders.Add(patientHealthcareProvider);
            _appDbContext.SaveChanges();
        }

        public void UpdatePatientHealthcareProvider(PatientHealthcareProvider patientHealthcareProvider)
        {
            _appDbContext.PatientHealthcareProviders.Update(patientHealthcareProvider);
            _appDbContext.SaveChanges();
        }

        public void DeletePatientHealthcareProvider(int healthcareProviderId, int id)
        {
            PatientHealthcareProvider patientHealthcareProvider = _appDbContext.PatientHealthcareProviders
                .Where(x => x.PatientId == id && x.HealthcareProviderId == healthcareProviderId)
                .SingleOrDefault();

            if (patientHealthcareProvider != null)
            {
                _appDbContext.PatientHealthcareProviders.Remove(patientHealthcareProvider);
                _appDbContext.SaveChanges();
            }
        }

        public PatientHealthcareProvider GetPatientHealthcareProviderByPatientId(int patientId)
        {
            return _appDbContext.PatientHealthcareProviders.FirstOrDefault(p => p.PatientId == patientId);
        }
    }
}
