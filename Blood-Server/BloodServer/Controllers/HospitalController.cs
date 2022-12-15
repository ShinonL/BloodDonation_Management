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
    [Route("hospital")]
    public class HospitalController : ControllerBase
    {
        IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok( _hospitalService.GetAll());
        }

        [HttpGet("get-staff")]
        public IActionResult GetStaff()
        {
            return Ok(_hospitalService.GetStaff());
        }

        [HttpGet("get-roles")]
        public IActionResult GetRoles()
        {
            return Ok(_hospitalService.GetRoles());
        }

        [HttpPost("create-appointment")]
        public IActionResult CreateAppointment([FromBody] AppointmentDTO appointment)
        {
            IActionResult result = Ok();
            try
            {
                _hospitalService.CreateAppointment(appointment);
            }
            catch (Exception ex)
            {
                result = BadRequest();
            }
            return result;
        }

        [HttpPost("create-staff")]
        public IActionResult CreateStaff([FromBody] StaffDTO staff)
        {
            IActionResult result = Ok();
            try
            {
                _hospitalService.CreateStaff(staff);
            }
            catch (Exception ex)
            {
                result = BadRequest();
            }
            return result;
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(string id)
        {
            IActionResult result = Ok();

            try
            {
                _hospitalService.Delete(id);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }

        [HttpPost("create-app/{id}")]
        public IActionResult CreateAppointmentId([FromBody] AppointmentDTO appointment, string id)
        {
            IActionResult result = Ok();
            try
            {
                _hospitalService.CreateAppointmentWithRequest(appointment, id);
            }
            catch (Exception ex)
            {
                result = BadRequest();
            }
            return result;
        }

        [HttpGet("get-appointments/{id}")]
        public IActionResult GetAppointments(string id)
        {
            return Ok(_hospitalService.GetAppointments(id));
        }

        [HttpGet("get-unconfirmed-appointments/{id}")]
        public IActionResult GetUnconfirmedAppointments(string id)
        {
            return Ok(_hospitalService.GetUnconfirmedAppointments(id));
        }

        [HttpGet("get-confirmed-appointments/{id}")]
        public IActionResult GetConfirmedAppointments(string id)
        {
            return Ok(_hospitalService.GetConfirmedAppointments(id));
        }

        [HttpPost("confirm-appointment")]
        public IActionResult ConfirmAppointment([FromBody] string id)
        {
            IActionResult result = Ok();
            try
            {
                _hospitalService.ConfirmAppointment(id);
            }
            catch (Exception ex)
            {
                result = BadRequest();
            }
            return result;
        }

        [HttpPost("add-blood-test")]
        public IActionResult AddBloodTest([FromBody] BloodTestDTO bloodTestDTO)
        {
            IActionResult result = Ok();

            try
            {
                _hospitalService.AddBloodTest(bloodTestDTO);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }
    }
}
