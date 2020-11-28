using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class UserRepository : CrudRepository<User>
    {
        public UserRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Auth(string email, string password)
        {
            return await _dbContext.User.Where( x => x.Email == email && x.Password == password ).FirstOrDefaultAsync();
        }
    }
}
