using MedCare_Hospital.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyHospital_MVC.DataAccess;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;

namespace MyHospital.DataAccess.Repositories
{
    public class MedicalRecordRepository: IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public MedicalRecordRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return _appDbContext.MedicalRecords.FirstOrDefault(m => m.MedicalRecordId == id);
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return _appDbContext.MedicalRecords.ToList();
        }

        //Get MedicalRecord By patientName
        public MedicalRecord GetMedicalRecordByPatientName(string name)
        {
            // Get the patient by name
            var patient = _appDbContext.Patients.FirstOrDefault(p => p.Name ==  name);

            if (patient != null)
            {
                // Get the medical record of the patient
                var medicalRecord = _appDbContext.MedicalRecords.FirstOrDefault(mr => mr.PatientId == patient.PatientId);
            }
            return _appDbContext.MedicalRecords.FirstOrDefault();
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            _appDbContext.MedicalRecords.Add(medicalRecord);
            _appDbContext.SaveChanges();
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            _appDbContext.MedicalRecords.Update(medicalRecord);
            _appDbContext.SaveChanges();
        }

        public void DeleteMedicalRecord(int id)
        {
            var medicalRecord = _appDbContext.MedicalRecords.FirstOrDefault(p => p.MedicalRecordId == id);
            if (medicalRecord != null)
            {
                _appDbContext.MedicalRecords.Remove(medicalRecord);
                _appDbContext.SaveChanges();
            }
        }
    }
}
