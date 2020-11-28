using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class CondominiumRuleServiceImpl : ICondominiumRuleService
    {
        private CondominiumRuleRepository _condominiumRuleRepository;
        public CondominiumRuleServiceImpl(neighlinkdbContext dbContext)
        {
            _condominiumRuleRepository = new CondominiumRuleRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _condominiumRuleRepository.Delete( id );
        }

        public async Task<IEnumerable<Condominiumrule>> GetByCondominium(int condominiumId)
        {
            return await _condominiumRuleRepository.GetByCondominium( condominiumId );
        }

        public async Task<Condominiumrule> GetById(int id)
        {
            return await _condominiumRuleRepository.GetById( id );
        }

        public async Task<Condominiumrule> Insert(Condominiumrule entity)
        {
            return await _condominiumRuleRepository.Insert( entity );
        }

        public async Task<IEnumerable<Condominiumrule>> List()
        {
            return await _condominiumRuleRepository.List();
        }

        public async Task<Condominiumrule> Update(Condominiumrule entity)
        {
            return await _condominiumRuleRepository.Update( entity );
        }
    }
}
