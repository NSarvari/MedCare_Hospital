using MyHospital.DataAccess.Repositories.IRepositories;
using MyHospital.Services.IServices;
using MyHospital_MVC.Models;

namespace MyHospital.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public void AddPatient(Patient patient)
        {
            patientRepository.AddPatient(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            patientRepository.UpdatePatient(patient);
        }

        public void DeletePatient(int id)
        {
            patientRepository.DeletePatient(id);
        }

        public Patient GetPatientById(int id)
        {
            return patientRepository.GetPatientById(id);
        }

        public List<Patient> GetAllPatients()
        {
            return patientRepository.GetAllPatients();
        }

        public Patient GetPatientByName(string name)
        {
            return patientRepository.GetAllPatients()
                .FirstOrDefault(p => p.Name == name);
        }
    }
}

