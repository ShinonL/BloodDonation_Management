using BloodServer.DTO;
using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Repository
{
    public class RequestRepository : IRequestRepository
    {
        BloodManagementContext _dbContext = new BloodManagementContext();

        public void CreateRequest(Request request)
        {
            _dbContext.Requests.Add(request);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = _dbContext.Requests.FirstOrDefault(r => r.Id == id);
            _dbContext.Requests.Remove(request);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Request> GetAll(int id)
        {
            var hospitalId = _dbContext.staff.FirstOrDefault(s => s.Id == id).HospitalId;
            return _dbContext.Requests.Include(r => r.Blood).Include(r => r.Staff).Where(r => r.Staff.HospitalId == hospitalId).ToList();
        }

        public void ConfirmRequest(int id)
        {
            var request = _dbContext.Requests.FirstOrDefault(r => r.Id == id);
            request.Confirmed = true;

            _dbContext.Requests.Update(request);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Request> GetAllReq()
        {
            return _dbContext.Requests.Include(r => r.Blood).Include(r => r.Staff).Include(s => s.Staff.Hospital).Where(r => r.Confirmed == false).ToList();
        }
    }
}
