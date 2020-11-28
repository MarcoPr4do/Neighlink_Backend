using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class ResidentRepository : CrudRepository<Resident>
    {
        public ResidentRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Resident> GetByUserId(int userId)
        {
            return await _dbContext.Resident.Where( x => x.UserId == userId ).FirstOrDefaultAsync();
        }

        public async Task<Resident> AuthToken(string token)
        {
            var user = await _dbContext.User.Where( x => x.Token == token ).FirstOrDefaultAsync();
            if (user == null) return null;
            var resident = await _dbContext.Resident.Where( x => x.UserId == user.UserId ).FirstOrDefaultAsync();
            if (resident == null) return null;
            resident.User = user;
            return resident;
        }
    }
}
