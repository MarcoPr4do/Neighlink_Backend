using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class BuildingServiceImpl : IBuildingService
    {
        private BuildingRepository _buildingRepository;

        public BuildingServiceImpl(neighlinkdbContext dbContext)
        {
            _buildingRepository = new BuildingRepository( dbContext );
        }


        public async Task Delete(int id)
        {
            await _buildingRepository.Delete( id );
        }

        public async Task<IEnumerable<Building>> GetAllByCondominium(int condominiumId)
        {
            return await _buildingRepository.GetAllByCondominium( condominiumId );
        }

        public async Task<Building> GetById(int id)
        {
            return await _buildingRepository.GetById( id );
        }

        public async Task<Building> Insert(Building entity)
        {
            return await _buildingRepository.Insert( entity );
        }

        public async Task<IEnumerable<Building>> List()
        {
            return await _buildingRepository.List();
        }

        public async Task<Building> Update(Building entity)
        {
            return await _buildingRepository.Update( entity );
        }
    }
}
