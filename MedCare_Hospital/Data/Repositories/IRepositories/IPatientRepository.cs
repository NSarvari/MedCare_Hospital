using MyHospital_MVC.Models;

namespace MyHospital.DataAccess.Repositories.IRepositories
{
    public interface IPatientRepository
    {
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        List<Patient> GetPatientsByFirstName(string name);
    }
}
