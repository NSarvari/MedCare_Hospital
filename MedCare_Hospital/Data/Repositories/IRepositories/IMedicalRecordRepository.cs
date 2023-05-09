using MyHospital_MVC.Models;

namespace MyHospital_MVC.DataAccess.Repositories.IRepositories
{
    public interface IMedicalRecordRepository
    {
        void AddMedicalRecord(MedicalRecord patient);
        void UpdateMedicalRecord(MedicalRecord patient);
        void DeleteMedicalRecord(int id);
        MedicalRecord GetMedicalRecordById(int id);
        List<MedicalRecord> GetAllMedicalRecords();
        List<MedicalRecord> GetMedicalRecordByPatientName(string name);
    }
}
