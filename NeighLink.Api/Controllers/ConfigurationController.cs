using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighLink.Api.Models;
using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Service;
using NeighLink.DateLayer.Service.Impls;
using shortid;

namespace NeighLink.Api.Controllers
{
    [Route( "configuration" )]
    [ApiController]
    public class ConfigurationController : BaseController
    {

        private readonly IAdministratorService _administratorService;
        private readonly IResidentDepartmentService _residentDepartmentService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly IBuildingService _buildingService;

        public ConfigurationController()
        {
            _administratorService = new AdministratorServiceImpl( context );
            _userService = new UserServiceImpl( context );
            _residentDepartmentService = new ResidentDepartmentServiceImpl( context );
            _departmentService = new DepartmentServiceImpl( context );
            _buildingService = new BuildingServiceImpl( context );
        }

        #region DEPARTMENT
        [HttpGet( "condominiums/{condominiumId}/buildings/{buildingId}/departments" )]
        public async Task<ActionResult<Response>> GetDepartmentsByBuilding(int condominiumId, int buildingId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _departmentService.GetAllByBuilding( buildingId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpGet( "condominiums/{condominiumId}/buildings/{buildingId}/departments/{deparmentId}" )]
        public async Task<ActionResult<Response>> GetDepartment(int condominiumId, int buildingId, int deparmentId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _departmentService.GetById( deparmentId );
                if (result == null)
                {
                    NotFoundResponse();
                }
                else
                {
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

        [HttpPost( "condominiums/{condominiumId}/buildings/{buildingId}/departments" )]
        public async Task<ActionResult<Response>> PostDepartmentsByBuilding(int condominiumId, int buildingId, [FromHeader] string Authorization, [FromBody] RequestDepartment request)
        {
            try
            {
                var building = await _buildingService.GetById( buildingId );
                if (building == null)
                {
                    NotFoundResponse();
                    return response;
                }
                var departments = await _departmentService.GetAllByBuilding( buildingId );
                building.NumberOfHomes = departments.Count() + 1;
                await _buildingService.Update( building );

                var code = ShortId.Generate();
                var department = new Department()
                {
                    BuildingId = buildingId,
                    Code = code,
                    CondominiumId = condominiumId,
                    IsDelete = false,
                    LimitRegister = request.LimitRegister ?? 0,
                    Name = request.Name
                };
                var departmentSaved = await _departmentService.Insert( department );
                OkResponse( departmentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPut( "condominiums/{condominiumId}/buildings/{buildingId}/departments" )]
        public async Task<ActionResult<Response>> UpdateDepartmentsByBuilding(int condominiumId, int buildingId, [FromHeader] string Authorization, [FromBody] RequestDepartment request)
        {
            try
            {
                var department = await _departmentService.GetById( request.Id );
                if (department == null)
                {
                    NotFoundResponse();
                    return response;
                }
                department.Name = request.Name;
                department.LimitRegister = request.LimitRegister ?? 0;
                var departmentSaved = await _departmentService.Update( department );
                OkResponse( departmentSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/buildings/{buildingId}/departments/{departmentId}" )]
        public async Task<ActionResult<Response>> DeleteResidentDepartment(int condominiumId, int buildingId, int departmentId, [FromHeader] string Authotization)
        {
            try
            {
                var department = await _departmentService.GetById( departmentId );
                if (department == null)
                {
                    NotFoundResponse();
                    return response;
                }

                department.IsDelete = true;
                await _departmentService.Update( department );
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

        #region BUILDING
        [HttpGet( "condominiums/{condominiumId}/buildings" )]
        public async Task<ActionResult<Response>> GetBuildingsByCondominium(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _buildingService.GetAllByCondominium( condominiumId );
                OkResponse( result );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpGet( "condominiums/{condominiumId}/buildings/{buildingId}" )]
        public async Task<ActionResult<Response>> GetBuilding(int condominiumId, int buildingId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _buildingService.GetById( buildingId );
                if (result == null)
                {
                    NotFoundResponse();
                }
                else
                {
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

        [HttpPost( "condominiums/{condominiumId}/buildings" )]
        public async Task<ActionResult<Response>> PostBuildinfByCondominium(int condominiumId, [FromHeader] string Authorization, [FromBody] RequestBuilding request)
        {
            try
            {
                var building = new Building()
                {
                    CondominiumId = condominiumId,
                    IsDelete = false,
                    Name = request.Name,
                    NumberOfHomes = 0,
                };
                var buildingSaved = await _buildingService.Insert( building );
                OkResponse( buildingSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }

        [HttpPut( "condominiums/{condominiumId}/buildings/{buildingId}" )]
        public async Task<ActionResult<Response>> UpdateBuilding(int condominiumId, int buildingId, [FromHeader] string Authorization, [FromBody] RequestBuilding request)
        {
            try
            {
                var building = await _buildingService.GetById( buildingId );
                if (building == null)
                {
                    NotFoundResponse();
                    return response;
                }
                building.Name = request.Name;
                var buildingSaved = await _buildingService.Update( building );
                OkResponse( buildingSaved );
                return response;
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return response;
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/buildings/{buildingId}" )]
        public async Task<ActionResult<Response>> DeleteBuilding(int condominiumId, int buildingId, [FromHeader] string Authotization)
        {
            try
            {
                var building = await _buildingService.GetById( buildingId );
                if (building == null)
                {
                    NotFoundResponse();
                    return response;
                }
                building.IsDelete = true;
                await _buildingService.Update( building );
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
