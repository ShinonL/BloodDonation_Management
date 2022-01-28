using BloodServer.DTO;
using BloodServer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodServer.Controllers
{
    [ApiController]
    [Route("request")]
    public class RequestController : ControllerBase
    {
        IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("create")]
        public IActionResult CreateRequest([FromBody] RequestDTO requestDTO)
        {
            IActionResult result = Ok();

            try
            {
                _requestService.CreateRequest(requestDTO);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }

        [HttpGet("get-all/{id}")]
        public IActionResult GetAllByStaffId(int id)
        {
            IActionResult result;

            try
            {
                var requests = _requestService.GetAll(id);
                result = Ok(requests);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result = Ok();

            try
            {
                _requestService.Delete(id);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            IActionResult result;

            try
            {
                var requests = _requestService.GetAllReq();
                result = Ok(requests);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }

        [HttpPost("confirm")]
        public IActionResult ConfrimRequest([FromBody] int id)
        {
            IActionResult result = Ok();

            try
            {
                _requestService.ConfirmRequest(id);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }
    }
}
