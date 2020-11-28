using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class NewsRepository : CrudRepository<News>
    {
        public NewsRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<News>> GetAllByCondominium(int condominiumId)
        {
            return await _dbContext.News.Where( x => x.CondominiumId == condominiumId ).ToListAsync();
        }
    }
}
