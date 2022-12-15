using BloodServer.DTO;
using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using BloodServer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Service
{
    public class RequestService : IRequestService
    {
        IRequestRepository _requestRepository;
        IBloodTypeService _bloodTypeService;

        public RequestService(IRequestRepository requestRepository, IBloodTypeService bloodTypeService)
        {
            _requestRepository = requestRepository;
            _bloodTypeService = bloodTypeService;
        }

        public void CreateRequest(RequestDTO requestDTO)
        {
            var request = new Request
            {
                TargetFirstName = requestDTO.TargetFirstName,
                TargetLastName = requestDTO.TargetLastName,
                BloodId = requestDTO.BloodId,
                Illness = requestDTO.Illness,
                StaffId = requestDTO.StaffId,
                RequestDate = DateTime.Now,
                Confirmed = false
            };

            _requestRepository.CreateRequest(request);
        }

        public IEnumerable<RequestDTO> GetAll(string id)
        {
            var requests = _requestRepository.GetAll(id).Select(
                request => { 
                    var requestDTO = new RequestDTO
                    {
                        Id = request.Id,
                        TargetFirstName = request.TargetFirstName,
                        TargetLastName = request.TargetLastName,
                        Blood = _bloodTypeService.GetById(request.BloodId ?? "6399f3bb41888565fca4ba36"),
                        Illness = request.Illness,
                        StaffId = request.StaffId,
                        RequestDate = request.RequestDate,
                        Confirmed = request.Confirmed,
                        Cnp = request.Cnp,
                    };
                    return requestDTO;
                });

            return requests;
        }

        public IEnumerable<RequestDTO> GetAllReq()
        {
            var requests = _requestRepository.GetAllReq().Select(
                request => {
                    var requestDTO = new RequestDTO
                    {
                        Id = request.Id,
                        TargetFirstName = request.TargetFirstName,
                        TargetLastName = request.TargetLastName,
                        Blood = _bloodTypeService.GetById(request.BloodId ?? "6399f3bb41888565fca4ba36"),
                        Illness = request.Illness,
                        Hospital = new HospitalDTO
                        {
                            Id = request.Staff.Hospital.Id,
                            Name = request.Staff.Hospital.Name,
                            Address = request.Staff.Hospital.Address,
                            PhoneNumber = request.Staff.Hospital.PhoneNumber
                        },
                        RequestDate = request.RequestDate,
                        Cnp = request.Cnp,
                    };
                    return requestDTO;
                });

            return requests;
        }

        public void ConfirmRequest(string id)
        {
            _requestRepository.ConfirmRequest(id);
        }

        public void Delete(string id)
        {
            _requestRepository.Delete(id);
        }
    }
}
