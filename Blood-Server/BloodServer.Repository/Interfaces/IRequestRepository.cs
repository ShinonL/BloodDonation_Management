using BloodServer.DTO;
using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Repository.Interfaces
{
    public interface IRequestRepository
    {
        public void CreateRequest(Request request);

        public IEnumerable<Request> GetAll(int id);

        public void ConfirmRequest(int id);

        public IEnumerable<Request> GetAllReq();

        public void Delete(int id);
    }
}
