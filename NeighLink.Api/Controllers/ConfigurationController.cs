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
        public async Task<IActionResult> GetDepartmentsByBuilding(int condominiumId, int buildingId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _departmentService.GetAllByBuilding( buildingId );
                OkResponse( result );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpGet( "condominiums/{condominiumId}/buildings/{buildingId}/departments/{deparmentId}" )]
        public async Task<IActionResult> GetDepartment(int condominiumId, int buildingId, int deparmentId, [FromHeader] string Authotization)
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
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPost( "condominiums/{condominiumId}/buildings/{buildingId}/departments" )]
        public async Task<IActionResult> PostDepartmentsByBuilding(int condominiumId, int buildingId, [FromHeader] string Authorization, [FromBody] RequestDepartment request)
        {
            try
            {
                var building = await _buildingService.GetById( buildingId );
                if (building == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
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
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPut( "condominiums/{condominiumId}/buildings/{buildingId}/departments" )]
        public async Task<IActionResult> UpdateDepartmentsByBuilding(int condominiumId, int buildingId, [FromHeader] string Authorization, [FromBody] RequestDepartment request)
        {
            try
            {
                var department = await _departmentService.GetById( request.Id );
                if (department == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }
                department.Name = request.Name;
                department.LimitRegister = request.LimitRegister ?? 0;
                var departmentSaved = await _departmentService.Update( department );
                OkResponse( departmentSaved );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/buildings/{buildingId}/departments/{departmentId}" )]
        public async Task<IActionResult> DeleteResidentDepartment(int condominiumId, int buildingId, int departmentId, [FromHeader] string Authotization)
        {
            try
            {
                var department = await _departmentService.GetById( departmentId );
                if (department == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }

                department.IsDelete = true;
                await _departmentService.Update( department );
                OkResponse( null );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        #endregion

        #region BUILDING
        [HttpGet( "condominiums/{condominiumId}/buildings" )]
        public async Task<IActionResult> GetBuildingsByCondominium(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _buildingService.GetAllByCondominium( condominiumId );
                OkResponse( result );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpGet( "condominiums/{condominiumId}/buildings/{buildingId}" )]
        public async Task<IActionResult> GetBuilding(int condominiumId, int buildingId, [FromHeader] string Authotization)
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
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPost( "condominiums/{condominiumId}/buildings" )]
        public async Task<IActionResult> PostBuildinfByCondominium(int condominiumId, [FromHeader] string Authorization, [FromBody] RequestBuilding request)
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
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPut( "condominiums/{condominiumId}/buildings/{buildingId}" )]
        public async Task<IActionResult> UpdateBuilding(int condominiumId, int buildingId, [FromHeader] string Authorization, [FromBody] RequestBuilding request)
        {
            try
            {
                var building = await _buildingService.GetById( buildingId );
                if (building == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }
                building.Name = request.Name;
                var buildingSaved = await _buildingService.Update( building );
                OkResponse( buildingSaved );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/buildings/{buildingId}" )]
        public async Task<IActionResult> DeleteBuilding(int condominiumId, int buildingId, [FromHeader] string Authotization)
        {
            try
            {
                var building = await _buildingService.GetById( buildingId );
                if (building == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }
                building.IsDelete = true;
                await _buildingService.Update( building );
                OkResponse( null );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        #endregion
    }
}
