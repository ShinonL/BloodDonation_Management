using BloodServer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Service.Interfaces
{
    public interface IRequestService
    {
        public void CreateRequest(RequestDTO requestDTO);

        public IEnumerable<RequestDTO> GetAll(string id);

        public IEnumerable<RequestDTO> GetAllReq();

        public void ConfirmRequest(string id);
        public void Delete(string id);
    }
}
