using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface IAdministratorService : ICrudService<Administrator>
    {
        Task<Administrator> Auth(string email, string password);
        Task<Administrator> AuthToken(string token);
    }
}
