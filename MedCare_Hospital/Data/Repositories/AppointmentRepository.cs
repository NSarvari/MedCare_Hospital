using MedCare_Hospital.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyHospital_MVC.DataAccess.Repositories.IRepositories;
using MyHospital_MVC.Models;
using System;

namespace MyHospital.DataAccess.Repositories
{
    namespace MyHospital_MVC.Repositories
    {
        public class AppointmentRepository : IAppointmentRepository
        {
            private readonly ApplicationDbContext _appDbContext;
            public AppointmentRepository(ApplicationDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            //Get appointment by patientName
            public List<Appointment> GetPatientAppointmentsById(int Id)
            {
                return this._appDbContext.Appointments.Where(a => a.PatientId == Id).ToList();
            }

            //Get appointment by healthcareProviderName
            public List<Appointment> GetHealthcareProviderAppointmentsById(int Id)
            {
                return this._appDbContext.Appointments.Where(a => a.HealthcareProviderId == Id).ToList();
            }

            public Appointment GetAppointmentById(int id)
            {
                return _appDbContext.Appointments.FirstOrDefault(m => m.AppointmentId == id);
            }

            public List<Appointment> GetAllAppointments()
            {
                return _appDbContext.Appointments.ToList();
            }

            public void AddAppointment(Appointment appointment)
            {

                    _appDbContext.Appointments.Add(appointment);
                    _appDbContext.SaveChanges();
                
            }

            public void UpdateAppointment(Appointment appointment)
            {
                _appDbContext.Appointments.Update(appointment);
                _appDbContext.SaveChanges();
            }

            public void DeleteAppointment(int id)
            {
                var appointment = _appDbContext.Appointments.FirstOrDefault(p => p.AppointmentId == id);
                if (appointment != null)
                {
                    _appDbContext.Appointments.Remove(appointment);
                    _appDbContext.SaveChanges();
                }
            }
        }
    }
}