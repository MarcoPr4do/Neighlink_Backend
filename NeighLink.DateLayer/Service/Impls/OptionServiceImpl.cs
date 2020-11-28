using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class OptionServiceImpl : IOptionService
    {
        private OptionRepository _optionRepository;
        public OptionServiceImpl(neighlinkdbContext dbContext)
        {
            _optionRepository = new OptionRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _optionRepository.Delete( id );
        }

        public async Task<IEnumerable<Option>> GetAllByPoll(int pollId)
        {
            return await _optionRepository.GetAllByPoll( pollId );
        }

        public async Task<Option> GetById(int id)
        {
            return await _optionRepository.GetById( id );
        }

        public async Task<Option> Insert(Option entity)
        {
            return await _optionRepository.Insert( entity );
        }

        public async Task<IEnumerable<Option>> List()
        {
            return await _optionRepository.List();
        }

        public async Task<Option> Update(Option entity)
        {
            return await _optionRepository.Update( entity );
        }
    }
}
