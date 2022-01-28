using BloodServer.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodServer.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class StocksController : ControllerBase
    {
        IStocksService _stocksService;

        public StocksController(IStocksService stockService)
        {
            _stocksService = stockService;
        }

        [HttpGet("get-stock")]
        public async Task<IActionResult> GetStock()
        {
            return Ok(_stocksService.GetAll());
        }
    }
}
