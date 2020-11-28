using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface ICondominiumRuleService : ICrudService<Condominiumrule>
    {
        Task<IEnumerable<Condominiumrule>> GetByCondominium(int condominiumId);
    }
}
