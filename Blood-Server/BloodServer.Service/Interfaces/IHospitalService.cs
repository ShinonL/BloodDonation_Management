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
        public HospitalDTO GetById(int id);

        public IEnumerable<AppointmentDTO> GetAppointments(int id);
        public IEnumerable<AppointmentDTO> GetUnconfirmedAppointments(int id);
        public IEnumerable<AppointmentDTO> GetConfirmedAppointments(int id);
        public void CreateAppointment(AppointmentDTO appointment);
        public void ConfirmAppointment(int id);
        public void AddBloodTest(BloodTestDTO bloodTestDTO);
        public void CreateAppointmentWithRequest(AppointmentDTO app, int id);
        public void CreateStaff(StaffDTO staffDTO);
        public void Delete(int id);
    }
}
