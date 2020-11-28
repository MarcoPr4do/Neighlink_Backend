using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class PaymentServiceImpl : IPaymentService
    {
        private PaymentRepository _paymentRepository;
        public PaymentServiceImpl(neighlinkdbContext dbContext)
        {
            _paymentRepository = new PaymentRepository( dbContext );
        }

        public async Task Delete(int id)
        {
            await _paymentRepository.Delete( id );
        }

        public async Task<IEnumerable<Payment>> GetByBill(int billId)
        {
            return await _paymentRepository.GetByBill( billId );
        }

        public async Task<Payment> GetById(int id)
        {
            return await _paymentRepository.GetById( id );
        }

        public async Task<Payment> Insert(Payment entity)
        {
            return await _paymentRepository.Insert( entity );
        }

        public async Task<IEnumerable<Payment>> List()
        {
            return await _paymentRepository.List();
        }

        public async Task<Payment> Update(Payment entity)
        {
            return await _paymentRepository.Update( entity );
        }
    }
}
