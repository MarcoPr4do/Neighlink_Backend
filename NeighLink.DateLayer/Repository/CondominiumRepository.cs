using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class CondominiumRepository:CrudRepository<Condominium>
    {
        public CondominiumRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Condominium>> GetAllByAdmin(int adminId) {
            return await _dbContext.Condominium.Where( x => x.AdministratorId == adminId && x.IsDelete == false ).ToListAsync();
        }
    }
}
