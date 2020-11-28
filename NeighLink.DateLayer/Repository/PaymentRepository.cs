using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class PaymentRepository : CrudRepository<Payment>
    {
        public PaymentRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetByBill(int billId)
        {
            return await _dbContext.Payment.Where( x => x.BillId == billId ).ToListAsync();
        }
    }
}
