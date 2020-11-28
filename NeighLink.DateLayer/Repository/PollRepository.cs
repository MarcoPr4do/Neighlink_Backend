using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class PollRepository : CrudRepository<Poll>
    {
        public PollRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Poll>> GetAllByCondominium(int condominiumId)
        {
            return await _dbContext.Poll.Where( x => x.CondominiumId == condominiumId && x.IsDelete == false ).ToListAsync();
        }
    }
}
