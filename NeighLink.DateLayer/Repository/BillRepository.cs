using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class BillRepository : CrudRepository<Bill>
    {
        public BillRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Bill>> GetAllByDepartment(int departmentId)
        {
            return await _dbContext.Bill.Where( x => x.DepartmentId == departmentId && x.IsDelete == false ).ToListAsync();
        }

        public async Task<IEnumerable<Bill>> GetAllByCondominium(int condominium)
        {
            return await _dbContext.Bill.Where( x => x.CondominiumId == condominium && x.IsDelete == false ).ToListAsync();
        }
    }
}
