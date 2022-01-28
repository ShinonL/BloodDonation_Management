using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodServer.Repository
{
    public class BloodTypeRepository : IBloodTypeRepository
    {
        BloodManagementContext _dbContext = new BloodManagementContext();
        public async Task<IEnumerable<BloodType>> GetBloodTypes()
        {
            return await _dbContext.BloodTypes.ToListAsync();
        }

        public BloodType GetById(int id)
        {
            return _dbContext.BloodTypes.FirstOrDefault(b => b.Id == id);
        }
    }
}
