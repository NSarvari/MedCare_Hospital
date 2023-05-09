using MyHospital_MVC.Models;

namespace MyHospital.Services.IServices
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
        Patient GetPatientById(int id);
        List<Patient> GetAllPatients();
        Patient GetPatientByName(string name);
    }
}
