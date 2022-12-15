﻿using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Repository.Interfaces
{
    public interface IHospitalRepository
    {
        public IEnumerable<Hospital> GetAll();
        public Hospital GetById(string id);
        public IEnumerable<Appointment> GetAppointments(string id);
        public IEnumerable<Appointment> GetUnconfirmedAppointments(string id);
        public IEnumerable<Appointment> GetConfirmedAppointments(string id);
        public void CreateAppointment(Appointment appointment);
        public void ConfirmAppointment(string id);
        public void AddBloodTest(BloodTest bloodTest);
        public IEnumerable<staff> GetStaff();
        public IEnumerable<Authorization> GetRoles();
        public void CreateStaff(staff staffDTO);
        public void Delete(string id);
    }
}
