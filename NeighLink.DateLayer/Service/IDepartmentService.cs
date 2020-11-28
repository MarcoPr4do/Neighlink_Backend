using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IDepartmentService : ICrudService<Department>
    {
        Task<Department> GetByCode(string code);
        Task<IEnumerable<Department>> GetAllByBuilding(int buildingIdd);
    }
}
