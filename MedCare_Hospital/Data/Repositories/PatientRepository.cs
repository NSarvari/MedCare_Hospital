using MedCare_Hospital.Data;
using MyHospital.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;

namespace MyHospital.DataAccess.Repositories
{
    public class PatientRepository: IPatientRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PatientRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Patient GetPatientById(int id)
        {
            return _appDbContext.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        public List<Patient> GetAllPatients()
        {
            return _appDbContext.Patients.ToList();
        }

        //Get Patient By name
        public List<Patient> GetPatientsByFirstName(string name)
        {
            return this._appDbContext.Patients.Where(x => x.Name == name).ToList();
        }

        public void AddPatient(Patient patient)
        {
            _appDbContext.Patients.Add(patient);
            _appDbContext.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            _appDbContext.Patients.Update(patient);
            _appDbContext.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            var patient = _appDbContext.Patients.FirstOrDefault(p => p.PatientId == id);
            if (patient != null)
            {
                _appDbContext.Patients.Remove(patient);
                _appDbContext.SaveChanges();
            }
        }
    }
}
