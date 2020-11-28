using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class PollServiceImpl : IPollService
    {
        private PollRepository _pollRepository;
        public PollServiceImpl(neighlinkdbContext dbContext)
        {
            _pollRepository = new PollRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _pollRepository.Delete( id );
        }

        public async Task<IEnumerable<Poll>> GetAllByCondominium(int condominiumId)
        {
            return await _pollRepository.GetAllByCondominium( condominiumId );
        }

        public async Task<Poll> GetById(int id)
        {
            return await _pollRepository.GetById( id );
        }

        public async Task<Poll> Insert(Poll entity)
        {
            return await _pollRepository.Insert( entity );
        }

        public async Task<IEnumerable<Poll>> List()
        {
            return await _pollRepository.List();
        }

        public async Task<Poll> Update(Poll entity)
        {
            return await _pollRepository.Update( entity );
        }
    }
}
