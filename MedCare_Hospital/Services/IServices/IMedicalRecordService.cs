using MyHospital_MVC.Models;

namespace MyHospital_MVC.Services.IServices
{
    public interface IMedicalRecordService
    {
        void AddMedicalRecord(MedicalRecord medicalRecord);
        void UpdateMedicalRecord(MedicalRecord medicalRecord);
        void DeleteMedicalRecord(int id);
        MedicalRecord GetMedicalRecordById(int id);
        List<MedicalRecord> GetAllMedicalRecords();
        MedicalRecord GetMedicalRecordByPatientName(string name);
    }
}
