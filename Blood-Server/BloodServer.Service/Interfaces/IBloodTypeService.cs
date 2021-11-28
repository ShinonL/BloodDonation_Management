using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BloodServer.DTO;

namespace BloodServer.Service.Interfaces
{
    public interface IBloodTypeService
    {
        public Task<IEnumerable<BloodTypeDTO>> GetBloodTypes();
    }
}
