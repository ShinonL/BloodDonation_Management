using BloodServer.DTO;
using BloodServer.Repository.Interfaces;
using BloodServer.Service.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodServer.Service
{
    public class BloodTypeService : IBloodTypeService
    {
        IBloodTypeRepository _bloodTypeRepository;

        public BloodTypeService(IBloodTypeRepository bloodTypeRepository)
        {
            _bloodTypeRepository = bloodTypeRepository;
        }

        public async Task<IEnumerable<BloodTypeDTO>> GetBloodTypes()
        {
            var bloodTypes = await _bloodTypeRepository.GetBloodTypes();

            return bloodTypes.Select(bt => new BloodTypeDTO
            {
                Id = bt.Id,
                Blood = bt.Blood,
                Rh = bt.Rh
            }).ToList();
        }

        public BloodTypeDTO GetById(string id)
        {
            var model = _bloodTypeRepository.GetById(id);
            return new BloodTypeDTO
            {
                Id = model.Id,
                Blood = model.Blood,
                Rh = model.Rh
            };
        }
    }
}
