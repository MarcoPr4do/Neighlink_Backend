using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class PaymentCategoryServiceImpl : IPaymentCategoryService
    {
        private PaymentCategoryRepository _paymentCategoryRepository;
        public PaymentCategoryServiceImpl(neighlinkdbContext dbContext)
        {
            _paymentCategoryRepository = new PaymentCategoryRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _paymentCategoryRepository.Delete( id );
        }

        public async Task<IEnumerable<Paymentcategory>> GetAllByCondomininum(int condominiumId)
        {
            return await _paymentCategoryRepository.GetAllByCondomininum( condominiumId );
        }

        public async Task<Paymentcategory> GetById(int id)
        {
            return await _paymentCategoryRepository.GetById( id );
        }

        public async Task<Paymentcategory> Insert(Paymentcategory entity)
        {
            return await _paymentCategoryRepository.Insert( entity );
        }

        public async Task<IEnumerable<Paymentcategory>> List()
        {
            return await _paymentCategoryRepository.List();
        }

        public async Task<Paymentcategory> Update(Paymentcategory entity)
        {
            return await _paymentCategoryRepository.Update( entity );
        }
    }
}
