using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class NewsServiceImpl : INewsService
    {
        private NewsRepository _newsRepository;
        public NewsServiceImpl(neighlinkdbContext dbContext)
        {
            _newsRepository = new NewsRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _newsRepository.Delete( id );
        }

        public async Task<IEnumerable<News>> GetAllByCondominium(int condominiumId)
        {
            return await _newsRepository.GetAllByCondominium( condominiumId );
        }

        public async Task<News> GetById(int id)
        {
            return await _newsRepository.GetById( id );
        }

        public async Task<News> Insert(News entity)
        {
            return await _newsRepository.Insert( entity );
        }

        public async Task<IEnumerable<News>> List()
        {
            return await _newsRepository.List();
        }

        public async Task<News> Update(News entity)
        {
            return await _newsRepository.Update( entity );
        }
    }
}
