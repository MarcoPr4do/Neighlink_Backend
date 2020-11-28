using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class ResidentDepartmentServiceImpl : IResidentDepartmentService
    {
        private ResidentDeparmentRepository _residentDeparmentRepository;
        public ResidentDepartmentServiceImpl(neighlinkdbContext dbContext)
        {
            _residentDeparmentRepository = new ResidentDeparmentRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _residentDeparmentRepository.Delete( id );
        }

        public async Task<IEnumerable<ResidentDepartment>> GetAllByCondominium(int condominiumId)
        {
            return await _residentDeparmentRepository.GetAllByCondominium( condominiumId );
        }

        public async Task<IEnumerable<ResidentDepartment>> GetAllByDepartment(int departmentId)
        {
            return await _residentDeparmentRepository.GetAllByDepartment( departmentId );
        }

        public async Task<ResidentDepartment> GetById(int id)
        {
            return await _residentDeparmentRepository.GetById( id );
        }

        public async Task<ResidentDepartment> Insert(ResidentDepartment entity)
        {
            return await _residentDeparmentRepository.Insert( entity );
        }

        public async Task<IEnumerable<ResidentDepartment>> List()
        {
            return await _residentDeparmentRepository.List();
        }

        public async Task<ResidentDepartment> Update(ResidentDepartment entity)
        {
            return await _residentDeparmentRepository.Update( entity );
        }
    }
}
