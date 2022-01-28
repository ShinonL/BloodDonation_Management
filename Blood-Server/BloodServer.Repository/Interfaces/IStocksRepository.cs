using BloodServer.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodServer.Repository.Interfaces
{
    public interface IStocksRepository
    {
        public IEnumerable<Stock> GetAll();
    }
}
