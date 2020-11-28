using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IResidentService : ICrudService<Resident>
    {
        Task<Resident> Auth(string email, string password);
        Task<Resident> AuthToken(string token);
    }
}
