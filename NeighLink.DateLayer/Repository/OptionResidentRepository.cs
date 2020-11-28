using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class OptionResidentRepository : CrudRepository<OptionResident>
    {
        public OptionResidentRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OptionResident>> GetAllByPoll(List<int> optionsId)
        {
            return await _dbContext.OptionResident.Where( x => optionsId.Contains( x.OptionId ) ).ToListAsync();
        }
    }
}
