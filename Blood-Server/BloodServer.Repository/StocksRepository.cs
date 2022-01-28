using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Repository
{
    public class StocksRepository : IStocksRepository
    {
        BloodManagementContext _dbContext = new BloodManagementContext();
        public IEnumerable<Stock> GetAll()
        {
            return _dbContext.Stocks.ToList();
        }
    }
}
