using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class OptionRepository : CrudRepository<Option>
    {
        public OptionRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Option>> GetAllByPoll(int pollId)
        {
            return await _dbContext.Option.Where( x => x.PollId == pollId ).ToListAsync();
        }
    }
}
