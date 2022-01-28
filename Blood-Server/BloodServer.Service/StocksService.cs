using BloodServer.DTO;
using BloodServer.Repository.Interfaces;
using BloodServer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Service
{
    public class StocksService : IStocksService
    {

        IHospitalService _hospitalService;
        IStocksRepository _stocksRepository;
        IBloodTypeService _bloodTypeService;
        public StocksService(IStocksRepository stocksRepository, IHospitalService hospitalService, IBloodTypeService bloodTypeService)
        {
            _stocksRepository = stocksRepository;
            _hospitalService = hospitalService;
            _bloodTypeService = bloodTypeService;
        }

        public IEnumerable<StockDTO> GetAll()
        {
            var stocks = _stocksRepository.GetAll().Select(
                stock =>
                {
                    var stockDTO = new StockDTO
                    {
                        Id = stock.Id,
                        Hospital = _hospitalService.GetById(stock.HospitalId ?? 0),
                        BloodType = _bloodTypeService.GetById(stock.BloodId ?? 0),
                        Quantity = stock.Quantity ?? 0
                    };
                    return stockDTO;
                });
            return stocks;
        }
    }
}
