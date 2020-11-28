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
    [Route( "profile" )]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly IResidentService _residentService;
        private readonly ICondominiumService _condominiumService;
        private readonly IAdministratorService _administratorService;
        private readonly IResidentDepartmentService _residentDepartmentService;
        private readonly IUserService _userService;
        private readonly ICondominiumRuleService _condominiumRuleService;
        private readonly IPlanMemberService _planMemberService;
        private readonly IDepartmentService _departmentService;

        public ProfileController()
        {
            _administratorService = new AdministratorServiceImpl( context );
            _residentService = new ResidentServiceImpl( context );
            _userService = new UserServiceImpl( context );
            _condominiumService = new CondominiumServiceImpl( context );
            _residentDepartmentService = new ResidentDepartmentServiceImpl( context );
            _condominiumRuleService = new CondominiumRuleServiceImpl( context );
            _planMemberService = new PlanMemberServiceImpl( context );
            _departmentService = new DepartmentServiceImpl( context );
        }

        [HttpPost( "users/auth" )]
        public async Task<ActionResult<Response>> Login([FromBody] RequestAuth request)
        {
            try
            {
                ResponseLogin responseLogin = new ResponseLogin();
                var admin = await _administratorService.Auth( request.Email, request.Password );
                var resident = await _residentService.Auth( request.Email, request.Password );
                if (admin == null && resident == null)
                {
                    UnauthorizedResponse();
                    return response;
                }

                if (admin != null)
                {
                    responseLogin.User = admin;
                    responseLogin.UserType = "ADMINISTRADOR";
                }
                else
                {
                    responseLogin.User = resident;
                    responseLogin.UserType = "RESIDENTE";
                }
                OkResponse( responseLogin );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }


        #region RESIDENTS
        [HttpGet( "residents/{id}" )]
        public async Task<ActionResult<Response>> GetResident(int id, [FromHeader] string Authotization)
        {
            try
            {
                var resident = await _residentService.GetById( id );
                if (resident == null)
                {
                    NotFoundResponse();
                    return response;
                }
                var user = await _userService.GetById( resident.UserId );
                resident.User = user;
                OkResponse( resident );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPost( "residents" )]
        public async Task<ActionResult<Response>> RegisterResident([FromHeader] string Authotization, [FromBody] RequestResident request)
        {
            try
            {
                var user = new User()
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = request.Password,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Token = Guid.NewGuid().ToString().Replace( "-", "" ),
                };
                var userSaved = await _userService.Insert( user );
                var resident = new Resident()
                {
                    IsBlocked = false,
                    UserId = userSaved.UserId
                };
                var residentSaved = await _residentService.Insert( resident );
                residentSaved.User = userSaved;
                OkResponse( residentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        #endregion

        #region ADMINISTRADOR
        [HttpGet( "administrators/{id}/planMembers" )]
        public async Task<ActionResult<Response>> GetPlanMember(int id, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _planMemberService.GetAllByAdmin( id );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPost( "administrators" )]
        public async Task<ActionResult<Response>> RegisterResident([FromHeader] string Authotization, [FromBody] RequestAdministrator request)
        {
            try
            {
                var user = new User()
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = request.Password,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Token = Guid.NewGuid().ToString().Replace( "-", "" ),
                };
                var userSaved = await _userService.Insert( user );
                var admin = new Administrator()
                {
                    PlanActivated = true,
                    IsBlocked = false,
                    UserId = userSaved.UserId
                };
                var adminSaved = await _administratorService.Insert( admin );
                adminSaved.User = userSaved;
                OkResponse( adminSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        #endregion

        #region CONDOMINIUMS
        [HttpGet( "administrators/{adminId}/condominiums" )]
        public async Task<ActionResult<Response>> GetCondominiums(int adminId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _condominiumService.GetAllByAdmin( adminId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpPost( "condominiums" )]
        public async Task<ActionResult<Response>> AddCondominium([FromHeader] string Authorization, [FromBody] Condominium request)
        {
            try
            {
                var admin = await _administratorService.AuthToken( Authorization );
                if (admin == null)
                {
                    UnauthorizedResponse();
                    return response;
                }

                request.AdministratorId = admin.AdministratorId;
                var condominiumSaved = await _condominiumService.Insert( request );
                OkResponse( condominiumSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpPut( "condominiums/{condominiumId}" )]
        public async Task<ActionResult<Response>> UpdateCondominium(int condominiumId, [FromHeader] string Authotization, [FromBody] Condominium request)
        {
            try
            {
                request.CondominiumId = condominiumId;
                var condominiumSaved = await _condominiumService.Update( request );
                OkResponse( condominiumSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "condominiums/{condominiumId}" )]
        public async Task<ActionResult<Response>> DeleteCondominium(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var condominium = await _condominiumService.GetById( condominiumId );
                condominium.IsDelete = true;
                await _condominiumService.Update( condominium );
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


        #region CONDOMINIUMS RULES
        [HttpGet( "condominiums/{condominiumId}/condominiumrules" )]
        public async Task<ActionResult<Response>> GetCondominiumsRules(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _condominiumRuleService.GetByCondominium( condominiumId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpPost( "condominiums/{condominiumId}/condominiumrules" )]
        public async Task<ActionResult<Response>> AddCondominium(int condominiumId, [FromHeader] string Authorization, [FromBody] Condominiumrule request)
        {
            try
            {
                var admin = await _administratorService.AuthToken( Authorization );
                if (admin == null)
                {
                    UnauthorizedResponse();
                    return response;
                }

                request.CondominiumId = condominiumId;
                var condominiumSaved = await _condominiumRuleService.Insert( request );
                OkResponse( condominiumSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpPut( "condominiums/{condominiumId}/condominiumrules/{condominiumRuleId}" )]
        public async Task<ActionResult<Response>> updateCondominiumRule(int condominiumId, int condominiumRuleId, [FromHeader] string Authotization, [FromBody] Condominiumrule request)
        {
            try
            {
                request.CondominiumId = condominiumId;
                request.CondominiumRuleId = condominiumRuleId;
                var condominiumRuleSaved = await _condominiumRuleService.Update( request );
                OkResponse( condominiumRuleSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/condominiumrules/{condominiumRuleId}" )]
        public async Task<ActionResult<Response>> DeleteCondominiumRule(int condominiumId, int condominiumRuleId, [FromHeader] string Authotization)
        {
            try
            {
                await _condominiumRuleService.Delete( condominiumRuleId );
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

        #region RESIDENT DEPARTMENT
        [HttpGet( "residentdepartments" )]
        public async Task<ActionResult<Response>> GetResidentDepartment(int? condominiumId, int? departmentId, [FromHeader] string Authotization)
        {
            try
            {
                if (condominiumId == null && departmentId == null)
                {
                    OkResponse( new ArrayList() );
                    return response;
                }
                if (condominiumId != null)
                {
                    var result = await _residentDepartmentService.GetAllByCondominium( condominiumId.Value );
                    OkResponse( result );
                }
                else
                {
                    var result = await _residentDepartmentService.GetAllByDepartment( departmentId.Value );
                    OkResponse( result );
                }
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPost( "residentdepartments" )]
        public async Task<ActionResult<Response>> AddResidentDepartment([FromHeader] string Authorization, [FromBody] RequestResidentdepartment request)
        {
            try
            {
                var resident = await _residentService.AuthToken( Authorization );
                if (resident == null)
                {
                    UnauthorizedResponse();
                    return response;
                }
                var department = await _departmentService.GetByCode( request.Code );
                if (department == null)
                {
                    NotFoundResponse();
                    return response;
                }

                var residentDepartment = new ResidentDepartment()
                {
                    BuildingId = department.BuildingId,
                    CondiminiumId = department.CondominiumId,
                    DepartmentId = department.DepartmentId,
                    IsDelete = false,
                    ResidentId = resident.ResidentId
                };
                var residentDepartmentSaved = await _residentDepartmentService.Insert( residentDepartment );
                OkResponse( residentDepartmentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "residentdepartments/{id}" )]
        public async Task<ActionResult<Response>> DeleteResidentDepartment(int id, [FromHeader] string Authotization)
        {
            try
            {
                var residentDepartment = await _residentDepartmentService.GetById( id );
                if (residentDepartment == null)
                {
                    NotFoundResponse();
                }
                else
                {
                    residentDepartment.IsDelete = true;
                    await _residentDepartmentService.Update( residentDepartment );
                    OkResponse( null );
                }
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
