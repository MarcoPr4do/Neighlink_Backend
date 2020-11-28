using Microsoft.EntityFrameworkCore;
using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Repository
{
    public class ResidentDeparmentRepository : CrudRepository<ResidentDepartment>
    {
        public ResidentDeparmentRepository(neighlinkdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ResidentDepartment>> GetAllByCondominium(int condominiumId)
        {
            return await _dbContext.ResidentDepartment.Where( x => x.CondiminiumId == condominiumId && x.IsDelete == false ).ToListAsync();
        }

        public async Task<IEnumerable<ResidentDepartment>> GetAllByDepartment(int departmentId)
        {
            return await _dbContext.ResidentDepartment.Where( x => x.DepartmentId == departmentId && x.IsDelete == false ).ToListAsync();
        }


    }
}
