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
    [Route("register")]
    public class RegisterController : ControllerBase
    {
        IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            IActionResult result = Ok();

            try
            {
                _userService.CreateUser(user);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }

        [HttpPost("get-id")]
        public IActionResult GetUserId([FromBody] UserDTO user)
        {
            IActionResult result;

            try
            {
                var userId = _userService.GetUserId(user);
                if (userId != -1) 
                { 
                    result = Ok(new LoggedUserDTO
                    {
                        Id = userId,
                        Role = "user"
                    });
                }
                else
                {
                    var model = _userService.GetStaffId(user.Username, user.Password);
                    result = Ok(new LoggedUserDTO
                    {
                        Id = model.Id,
                        Role = _userService.GetStaffRole(model.AuthorizationId ?? 0)
                    });
                }

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
                result = Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.ToString());
            }

            return result;
        }
    }
}
