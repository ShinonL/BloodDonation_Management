using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Repository.Interfaces
{
    public interface IHospitalRepository
    {
        public IEnumerable<Hospital> GetAll();
        public Hospital GetById(int id);
        public IEnumerable<Appointment> GetAppointments(int id);
        public IEnumerable<Appointment> GetUnconfirmedAppointments(int id);
        public IEnumerable<Appointment> GetConfirmedAppointments(int id);
        public void CreateAppointment(Appointment appointment);
        public void ConfirmAppointment(int id);
        public void AddBloodTest(BloodTest bloodTest);
        public IEnumerable<staff> GetStaff();
        public IEnumerable<Authorization> GetRoles();
        public void CreateStaff(staff staffDTO);
        public void Delete(int id);
    }
}
