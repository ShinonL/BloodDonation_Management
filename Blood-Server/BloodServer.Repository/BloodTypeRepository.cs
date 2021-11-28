using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
