using BloodServer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Service.Interfaces
{
    public interface IStocksService
    {
        public IEnumerable<StockDTO> GetAll();
    }
}
