using MedCare_Hospital.Data;
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
        public List<MedicalRecord> GetMedicalRecordByPatientName(string name)
        {
            return this._appDbContext.MedicalRecords.Where(mr => mr.Patient.Name == name).ToList();
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
