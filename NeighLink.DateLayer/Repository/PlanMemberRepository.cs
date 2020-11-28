using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
   public  class PlanMemberRepository:CrudRepository<Planmember>
    {
        public PlanMemberRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Planmember>> GetAllByAdmin(int adminId) {
            return await _dbContext.Planmember.Where( x => x.AdministratorId == adminId ).ToListAsync();
        }
    }
}
