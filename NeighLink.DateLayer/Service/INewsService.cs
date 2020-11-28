using NeighLink.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service
{
    public interface INewsService : ICrudService<News>
    {
        Task<IEnumerable<News>> GetAllByCondominium(int condominiumId);
    }
}
