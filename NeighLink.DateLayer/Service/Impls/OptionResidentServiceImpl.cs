using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class OptionResidentServiceImpl : IOptionResidentService
    {
        private OptionResidentRepository _optionResidentRepository;
        public OptionResidentServiceImpl(neighlinkdbContext dbContext)
        {
            _optionResidentRepository = new OptionResidentRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _optionResidentRepository.Delete( id );
        }

        public async Task<IEnumerable<OptionResident>> GetAllByPoll(List<int> optionsId)
        {
            return await _optionResidentRepository.GetAllByPoll( optionsId );
        }

        public async Task<OptionResident> GetById(int id)
        {
            return await _optionResidentRepository.GetById( id );
        }

        public async Task<OptionResident> Insert(OptionResident entity)
        {
            return await _optionResidentRepository.Insert( entity );
        }

        public async Task<IEnumerable<OptionResident>> List()
        {
            return await _optionResidentRepository.List();
        }

        public async Task<OptionResident> Update(OptionResident entity)
        {
            return await _optionResidentRepository.Update( entity );
        }
    }
}
