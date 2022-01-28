using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        BloodManagementContext _dbContext = new BloodManagementContext();
        public IEnumerable<Hospital> GetAll()
        {
            return _dbContext.Hospitals.ToList();
        }

        public IEnumerable<staff> GetStaff()
        {
            return _dbContext.staff.Include(s => s.Hospital).Include(s => s.Authorization).ToList();
        }

        public IEnumerable<Authorization> GetRoles()
        {
            return _dbContext.Authorizations.ToList();
        }

        public Hospital GetById(int id)
        {
            return _dbContext.Hospitals.FirstOrDefault(h => h.Id == id);
        }

        public void Delete(int id)
        {
            var request = _dbContext.staff.FirstOrDefault(r => r.Id == id);
            _dbContext.staff.Remove(request);
            _dbContext.SaveChanges();
        }

        public void CreateAppointment(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
        }

        public void CreateStaff(staff staffDTO)
        {
            _dbContext.staff.Add(staffDTO);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Appointment> GetAppointments(int id)
        {
            return _dbContext.Appointments.Include(a => a.BloodTests).Where(a => a.UserId == id).ToList();
        }

        public IEnumerable<Appointment> GetUnconfirmedAppointments(int id)
        {
            var hospitalId = _dbContext.staff.FirstOrDefault(s => s.Id == id).HospitalId;
            return _dbContext.Appointments.Include(a => a.User).Include(a => a.Hospital).Where(a => a.HospitalId == hospitalId && a.Confirmed == false);
        }

        public IEnumerable<Appointment> GetConfirmedAppointments(int id)
        {
            var hospitalId = _dbContext.staff.FirstOrDefault(s => s.Id == id).HospitalId;
            return _dbContext.Appointments.Include(a => a.User).Include(a => a.Hospital).Include(a => a.BloodTests).Where(a => a.HospitalId == hospitalId && a.Confirmed == true);
        }

        public void ConfirmAppointment(int id)
        {
            var appointment = _dbContext.Appointments.Include(a => a.User).FirstOrDefault(a => a.Id == id);
            appointment.Confirmed = true;

            _dbContext.Update(appointment);

            var stock = _dbContext.Stocks.FirstOrDefault(s => s.HospitalId == appointment.HospitalId && s.BloodId == appointment.User.BloodId);
            if (stock != null)
            {
                stock.Quantity += 0.45;
                _dbContext.Update(stock);
            } else
            {
                var newStock = new Stock
                {
                    Quantity = 0.45,
                    BloodId = appointment.User.BloodId,
                    HospitalId = appointment.HospitalId
                };
                _dbContext.Stocks.Add(newStock);
            }

            _dbContext.SaveChanges();
        }

        public void AddBloodTest(BloodTest bloodTest)
        {
            _dbContext.BloodTests.Add(bloodTest);
            _dbContext.SaveChanges();
        }
    }
}
