using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BloodServer.DTO.Models;

namespace BloodServer.Repository.Interfaces
{
    public interface IBloodTypeRepository
    {
        public Task<IEnumerable<BloodType>> GetBloodTypes();
        public BloodType GetById(int id);
    }
}
