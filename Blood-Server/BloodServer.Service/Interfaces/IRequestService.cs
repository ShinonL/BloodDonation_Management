using BloodServer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Service.Interfaces
{
    public interface IRequestService
    {
        public void CreateRequest(RequestDTO requestDTO);

        public IEnumerable<RequestDTO> GetAll(int id);

        public IEnumerable<RequestDTO> GetAllReq();

        public void ConfirmRequest(int id);
        public void Delete(int id);
    }
}
