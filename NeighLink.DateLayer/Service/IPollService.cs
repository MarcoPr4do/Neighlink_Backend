using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IPollService : ICrudService<Poll>
    {
        Task<IEnumerable<Poll>> GetAllByCondominium(int condominiumId);
    }
}
