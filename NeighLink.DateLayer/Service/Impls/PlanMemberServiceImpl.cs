using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class PlanMemberServiceImpl : IPlanMemberService
    {
        private PlanMemberRepository _planMemberRepository;
        public PlanMemberServiceImpl(neighlinkdbContext dbContext)
        {
            _planMemberRepository = new PlanMemberRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _planMemberRepository.Delete( id );
        }

        public async Task<IEnumerable<Planmember>> GetAllByAdmin(int adminId)
        {
            return await _planMemberRepository.GetAllByAdmin( adminId );
        }

        public async Task<Planmember> GetById(int id)
        {
            return await _planMemberRepository.GetById( id );
        }

        public async Task<Planmember> Insert(Planmember entity)
        {
            return await _planMemberRepository.Insert( entity );
        }

        public async Task<IEnumerable<Planmember>> List()
        {
            return await _planMemberRepository.List();
        }

        public async Task<Planmember> Update(Planmember entity)
        {
            return await _planMemberRepository.Update( entity );
        }
    }
}
