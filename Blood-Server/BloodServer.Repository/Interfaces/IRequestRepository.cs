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

        public IEnumerable<Request> GetAll(string id);

        public void ConfirmRequest(string id);

        public IEnumerable<Request> GetAllReq();

        public void Delete(string id);
    }
}
