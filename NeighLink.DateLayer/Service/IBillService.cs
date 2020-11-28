using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IBillService:ICrudService<Bill>
    {
        Task<IEnumerable<Bill>> GetAllByDepartment(int departmentId);
        Task<IEnumerable<Bill>> GetAllByCondominium(int condominium);
    }
}
