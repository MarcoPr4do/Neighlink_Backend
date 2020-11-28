using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IOptionResidentService : ICrudService<OptionResident>
    {
        Task<IEnumerable<OptionResident>> GetAllByPoll(List<int> optionsId);
    }
}
