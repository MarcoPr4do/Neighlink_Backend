using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class BuildingRepository:CrudRepository<Building>
    {
        public BuildingRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Building>> GetAllByCondominium(int condominiumId) {
            return await _dbContext.Building.Where( x => x.CondominiumId == condominiumId && x.IsDelete == false ).ToListAsync();
        }
    }
}
