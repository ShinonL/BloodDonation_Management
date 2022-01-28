using BloodServer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodServer.Controllers
{
    [ApiController]
    [Route("blood")]
    public class BloodTypeController : ControllerBase
    {
        IBloodTypeService _bloodTypeService;

        public BloodTypeController(IBloodTypeService bloodTypeService)
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
