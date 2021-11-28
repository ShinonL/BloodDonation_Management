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
        IBloodTypeService _bloodTypeService;

        public RegisterController(IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        [HttpGet("getBloodTypes")]
        public async Task<IActionResult> GetBloodTypes()
        {
            return Ok(await _bloodTypeService.GetBloodTypes());
        }
    }
}
