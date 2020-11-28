using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class AdministratorRepository : CrudRepository<Administrator>
    {
        public AdministratorRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Administrator> GetByUserId(int userId)
        {
            return await _dbContext.Administrator.Where( x => x.UserId == userId ).FirstOrDefaultAsync();
        }

        public async Task<Administrator> AuthToken(string token)
        {
            var user = await _dbContext.User.Where( x => x.Token == token ).FirstOrDefaultAsync();
            if (user == null) return null;
            var admin = await _dbContext.Administrator.Where( x => x.UserId == user.UserId ).FirstOrDefaultAsync();
            if (admin == null) return null;
            admin.User = user;
            return admin;
        }
    }
}
