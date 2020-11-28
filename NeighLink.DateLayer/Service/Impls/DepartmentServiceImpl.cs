using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class DepartmentServiceImpl : IDepartmentService
    {
        private DepartmentRepository _departmentRepository;
        public DepartmentServiceImpl(neighlinkdbContext dbContext)
        {
            _departmentRepository = new DepartmentRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _departmentRepository.Delete( id );
        }

        public async Task<IEnumerable<Department>> GetAllByBuilding(int buildingIdd)
        {
            return await _departmentRepository.GetAllByBuilding( buildingIdd );
        }

        public async Task<Department> GetByCode(string code)
        {
            return await _departmentRepository.GetByCode( code );
        }

        public async Task<Department> GetById(int id)
        {
            return await _departmentRepository.GetById( id );
        }

        public async Task<Department> Insert(Department entity)
        {
            return await _departmentRepository.Insert( entity );
        }

        public async Task<IEnumerable<Department>> List()
        {
            return await _departmentRepository.List();
        }

        public async Task<Department> Update(Department entity)
        {
            return await _departmentRepository.Update( entity );
        }
    }
}
