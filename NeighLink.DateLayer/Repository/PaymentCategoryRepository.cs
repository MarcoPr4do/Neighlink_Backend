using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class PaymentCategoryRepository : CrudRepository<Paymentcategory>
    {
        public PaymentCategoryRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Paymentcategory>> GetAllByCondomininum(int condominiumId)
        {
            return await _dbContext.Paymentcategory.Where( x => x.CondominiumId == condominiumId && x.IsDelete == false ).ToListAsync();
        }
    }
}
