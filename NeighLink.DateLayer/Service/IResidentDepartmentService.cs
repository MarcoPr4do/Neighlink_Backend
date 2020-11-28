using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IResidentDepartmentService : ICrudService<ResidentDepartment>
    {
        Task<IEnumerable<ResidentDepartment>> GetAllByCondominium(int condominiumId);
        Task<IEnumerable<ResidentDepartment>> GetAllByDepartment(int departmentId);
    }
}
