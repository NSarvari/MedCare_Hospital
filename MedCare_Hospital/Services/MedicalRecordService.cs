using MyHospital.DataAccess.Repositories;
using MyHospital.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;
using MyHospital_MVC.Services.IServices;

namespace MyHospital_MVC.Services
{
    public class MedicalRecordService:IMedicalRecordService
    {
        private readonly IMedicalRecordRepository medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecordRepository.AddMedicalRecord(medicalRecord);
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecordRepository.UpdateMedicalRecord(medicalRecord);
        }

        public void DeleteMedicalRecord(int id)
        {
            medicalRecordRepository.DeleteMedicalRecord(id);
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return medicalRecordRepository.GetMedicalRecordById(id);
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return medicalRecordRepository.GetAllMedicalRecords();
        }

        public MedicalRecord GetMedicalRecordByPatientName(string name)
        {
            return medicalRecordRepository.GetMedicalRecordByPatientName(name)
                .FirstOrDefault();
        }
    }
}
