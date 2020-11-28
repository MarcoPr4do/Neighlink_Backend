using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class BillServiceImpl : IBillService
    {
        private BillRepository _billRepository;

        public BillServiceImpl(neighlinkdbContext dbContext)
        {
            _billRepository = new BillRepository( dbContext );
        }

        public async Task Delete(int id)
        {
            await _billRepository.Delete( id );
        }

        public async Task<IEnumerable<Bill>> GetAllByCondominium(int condominium)
        {
            return await _billRepository.GetAllByCondominium( condominium );
        }

        public async Task<IEnumerable<Bill>> GetAllByDepartment(int departmentId)
        {
            return await _billRepository.GetAllByDepartment( departmentId );
        }

        public async Task<Bill> GetById(int id)
        {
            return await _billRepository.GetById( id );
        }

        public async Task<Bill> Insert(Bill entity)
        {
            return await _billRepository.Insert( entity );
        }

        public async Task<IEnumerable<Bill>> List()
        {
            return await _billRepository.List(); ;
        }

        public async Task<Bill> Update(Bill entity)
        {
            return await _billRepository.Update( entity );
        }
    }
}
