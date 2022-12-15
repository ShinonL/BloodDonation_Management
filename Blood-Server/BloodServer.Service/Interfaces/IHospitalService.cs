using BloodServer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Service.Interfaces
{
    public interface IHospitalService
    {
        public IEnumerable<HospitalDTO> GetAll();
        public IEnumerable<StaffDTO> GetStaff();
        public IEnumerable<AuthorizationDTO> GetRoles();
        public HospitalDTO GetById(string id);

        public IEnumerable<AppointmentDTO> GetAppointments(string id);
        public IEnumerable<AppointmentDTO> GetUnconfirmedAppointments(string id);
        public IEnumerable<AppointmentDTO> GetConfirmedAppointments(string id);
        public void CreateAppointment(AppointmentDTO appointment);
        public void ConfirmAppointment(string id);
        public void AddBloodTest(BloodTestDTO bloodTestDTO);
        public void CreateAppointmentWithRequest(AppointmentDTO app, string id);
        public void CreateStaff(StaffDTO staffDTO);
        public void Delete(string id);
    }
}
