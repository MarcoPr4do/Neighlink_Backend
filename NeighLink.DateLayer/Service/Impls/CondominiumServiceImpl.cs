using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class CondominiumServiceImpl : ICondominiumService
    {
        private CondominiumRepository _condominiumRepository;

        public CondominiumServiceImpl(neighlinkdbContext dbContext)
        {
            _condominiumRepository = new CondominiumRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _condominiumRepository.Delete( id );
        }

        public async Task<IEnumerable<Condominium>> GetAllByAdmin(int adminId)
        {
            return await _condominiumRepository.GetAllByAdmin( adminId );
        }

        public async Task<Condominium> GetById(int id)
        {
            return await _condominiumRepository.GetById( id );
        }

        public async Task<Condominium> Insert(Condominium entity)
        {
            return await _condominiumRepository.Insert( entity );
        }

        public async Task<IEnumerable<Condominium>> List()
        {
            return await _condominiumRepository.List();
        }

        public async Task<Condominium> Update(Condominium entity)
        {
            return await _condominiumRepository.Update( entity );
        }
    }
}
