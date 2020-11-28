using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighLink.Api.Models;
using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Service;
using NeighLink.DateLayer.Service.Impls;

namespace NeighLink.Api.Controllers
{
    [Route( "info" )]
    [ApiController]
    public class InfoController : BaseController
    {
        private readonly IBillService _billService;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentCategoryService _paymentCategoryService;
        private readonly IAdministratorService _administratorService;
        private readonly IResidentService _residentService;
        private readonly IUserService _userService;

        public InfoController()
        {
            _billService = new BillServiceImpl( context );
            _paymentService = new PaymentServiceImpl( context );
            _paymentCategoryService = new PaymentCategoryServiceImpl( context );
            _administratorService = new AdministratorServiceImpl( context );
            _residentService = new ResidentServiceImpl( context );
            _userService = new UserServiceImpl( context );
        }

        #region BILL
        [HttpGet( "condominiums/{condominiumId}/departments/{departmentId}/bills" )]
        public async Task<ActionResult<Response>> GetBillsByDepartment(int condominiumId, int departmentId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _billService.GetAllByDepartment( departmentId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpGet( "condominiums/{condominiumId}/bills" )]
        public async Task<ActionResult<Response>> GetBillsByCondominium(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _billService.GetAllByCondominium( condominiumId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPost( "condominiums/{condominiumId}/departments/{departmentId}/bills" )]
        public async Task<ActionResult<Response>> PostBillByDepartment(int condominiumId, int departmentId, [FromHeader] string Authorization, [FromBody] RequestBill request)
        {
            try
            {
                var admin = await _administratorService.AuthToken( Authorization );
                if (admin == null)
                {
                    UnauthorizedResponse();
                    return response;
                }

                var bill = new Bill()
                {

                    AdministratorId = admin.AdministratorId,
                    Amount = request.Amount,
                    CondominiumId = condominiumId,
                    DepartmentId = departmentId,
                    Description = request.Description,
                    EndDate = request.EndDate,
                    StartDate = request.StartDate,
                    IsDelete = false,
                    Name = request.Name,
                    PaymentCategoryId = request.PaymentCategoryId
                };
                var billSaved = await _billService.Insert( bill );
                OkResponse( billSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpPut( "condominiums/{condominiumId}/departments/{departmentId}/bills/{billId}" )]
        public async Task<ActionResult<Response>> updateCondominiumRule(int condominiumId, int departmentId, int billId, [FromHeader] string Authotization, [FromBody] RequestBill request)
        {
            try
            {
                var bill = await _billService.GetById( billId );
                if (bill == null)
                {
                    NotFoundResponse();
                    return response;
                }

                bill.Name = request.Name;
                bill.Description = request.Description;
                bill.Amount = request.Amount;
                bill.StartDate = request.StartDate;
                bill.EndDate = request.EndDate;
                bill.PaymentCategoryId = request.PaymentCategoryId;
                var billSaved = await _billService.Update( bill );
                OkResponse( billSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/departments/{departmentId}/bills/{billId}" )]
        public async Task<ActionResult<Response>> DeleteBillsByCondominium(int condominiumId, int departmentId, int billId, [FromHeader] string Authotization)
        {
            try
            {
                var bill = await _billService.GetById( billId );
                if (bill == null)
                {
                    NotFoundResponse();
                    return response;
                }
                bill.IsDelete = true;
                await _billService.Update( bill );
                OkResponse( null );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        #endregion

        #region PAY
        [HttpGet( "departments/{departmentId}/bills/{billId}/pays" )]
        public async Task<ActionResult<Response>> GetResidentDepartment(int departmentId, int billId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _paymentService.GetByBill( billId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPost( "departments/{departmentId}/bills/{billId}/pays" )]
        public async Task<ActionResult<Response>> AddResidentDepartment(int departmentId, int billId, [FromHeader] string Authorization, [FromBody] RequestPayment request)
        {
            try
            {
                var resident = await _residentService.AuthToken( Authorization );
                if (resident == null)
                {
                    NotFoundResponse();
                    return response;
                }

                var payment = new Payment()
                {
                    Amount = request.Amount,
                    ConfirmPaid = false,
                    BillId = billId,
                    PaymentDate = DateTime.Now,
                    ResidentId = resident.ResidentId,
                    ResidentUserId = resident.UserId,
                    UrlImage = request.UrlImage
                };
                var paymentSaved = await _paymentService.Insert( payment );
                OkResponse( paymentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPut( "departments/{departmentId}/bills/{billId}/pays/{payId}/accept" )]
        public async Task<ActionResult<Response>> AcceptPayment(int departmentId, int billId, int payId, [FromHeader] string Authotization)
        {
            try
            {
                var payment = await _paymentService.GetById( payId );
                payment.ConfirmPaid = true;
                var paymentSaved = await _paymentService.Update( payment );
                OkResponse( paymentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPut( "departments/{departmentId}/bills/{billId}/pays/{payId}/denny" )]
        public async Task<ActionResult<Response>> DennytPayment(int departmentId, int billId, int payId, [FromHeader] string Authotization)
        {
            try
            {
                var payment = await _paymentService.GetById( payId );
                payment.ConfirmPaid = false;
                var paymentSaved = await _paymentService.Update( payment );
                OkResponse( paymentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        #endregion 

        #region PAYMENT CATEGORY
        [HttpGet( "condominiums/{condominiumId}/paymentCategories" )]
        public async Task<ActionResult<Response>> GetResidentDepartment(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _paymentCategoryService.GetAllByCondomininum( condominiumId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPost( "condominiums/{condominiumId}/paymentCategories" )]
        public async Task<ActionResult<Response>> AddResidentDepartment(int condominiumId, [FromHeader] string Authorization, [FromBody] RequestPaymentCategory request)
        {
            try
            {
                var paymentCategory = new Paymentcategory()
                {
                    CondominiumId = condominiumId,
                    Description = request.Description,
                    Name = request.Name,
                    IsDelete = false
                };
                var paymentCategorySaved = await _paymentCategoryService.Insert( paymentCategory );
                OkResponse( paymentCategorySaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/paymentCategories/{paymentCategoryId}" )]
        public async Task<ActionResult<Response>> DeleteResidentDepartment(int condominiumId, int paymentCategoryId, [FromHeader] string Authotization)
        {
            try
            {
                var paymentCategory = await _paymentCategoryService.GetById( paymentCategoryId );
                paymentCategory.IsDelete = true;
                await _paymentCategoryService.Update( paymentCategory );
                OkResponse( null );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        #endregion
    }


}
