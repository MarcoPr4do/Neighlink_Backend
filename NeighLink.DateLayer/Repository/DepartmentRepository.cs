using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class DepartmentRepository : CrudRepository<Department>
    {
        public DepartmentRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> GetByCode(string code)
        {
            return await _dbContext.Department.Where( x => x.Code == code && x.IsDelete == false ).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Department>> GetAllByBuilding(int buildingIdd)
        {
            return await _dbContext.Department.Where( x => x.BuildingId == buildingIdd && x.IsDelete == false ).ToListAsync();
        }
    }
}
