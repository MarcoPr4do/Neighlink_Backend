using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighLink.Api.Models;
using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Service;
using NeighLink.DateLayer.Service.Impls;

namespace NeighLink.Api.Controllers
{
    [Route( "interaction" )]
    [ApiController]
    public class InteractionController : BaseController
    {
        private readonly INewsService _newsService;
        private readonly IOptionService _optionService;
        private readonly IOptionResidentService _optionResidentService;
        private readonly IPollService _pollService;
        private readonly IAdministratorService _administratorService;
        private readonly IResidentService _residentService;
        private readonly IUserService _userService;

        public InteractionController()
        {
            _administratorService = new AdministratorServiceImpl( context );
            _residentService = new ResidentServiceImpl( context );
            _userService = new UserServiceImpl( context );
            _newsService = new NewsServiceImpl( context );
            _optionResidentService = new OptionResidentServiceImpl( context );
            _optionService = new OptionServiceImpl( context );
            _pollService = new PollServiceImpl( context );
        }

        #region News
        [HttpGet( "condominiums/{condominiumId}/news" )]
        public async Task<IActionResult> GetNewsByCondominium(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _newsService.GetAllByCondominium( condominiumId );
                OkResponse( result );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPost( "condominiums/{condominiumId}/news" )]
        public async Task<IActionResult> AddNews(int condominiumId, [FromHeader] string Authorization, [FromBody] RequestNews request)
        {
            try
            {
                var news = new News()
                {
                    CondominiumId = condominiumId,
                    Date = DateTime.Now,
                    Description = request.Description,
                    Title = request.Title,
                };
                var newsSaved = await _newsService.Insert( news );
                OkResponse( newsSaved );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpPut( "condominiums/{condominiumId}/news/{newsId}" )]
        public async Task<IActionResult> UpdateNews(int condominiumId, int newsId, [FromHeader] string Authotization, [FromBody] RequestNews request)
        {
            try
            {
                var news = await _newsService.GetById( newsId );
                if (news == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }
                news.Title = request.Title;
                news.Description = request.Description;
                var newsSaved = await _newsService.Update( news );
                OkResponse( newsSaved );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpDelete( "/condominiums/{condominiumId}/news/{newsId}" )]
        public async Task<IActionResult> DeleteNews(int condominiumId, int newsId, [FromHeader] string Authotization)
        {
            try
            {
                await _newsService.Delete( newsId );
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

        #region POLL
        [HttpGet( "condominiums/{condominiumId}/polls" )]
        public async Task<IActionResult> GetPollByCondominium(int condominiumId, [FromHeader] string Authotization)
        {
            try
            {
                var result = await _pollService.GetAllByCondominium( condominiumId );
                OkResponse( result );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPost( "condominiums/{condominiumId}/polls" )]
        public async Task<IActionResult> AddNews(int condominiumId, [FromHeader] string Authorization, [FromBody] RequestPoll request)
        {
            try
            {
                var admin = await _administratorService.AuthToken( Authorization );
                if (admin == null)
                {
                    UnauthorizedResponse();
                    return new ObjectResult(response);
                }

                var poll = new Poll()
                {
                    AdministratorId = admin.AdministratorId,
                    CondominiumId = condominiumId,
                    Description = request.Description,
                    EndDate = request.EndDate,
                    StartDate = request.StartDate,
                    IsDelete = false,
                    Title = request.Title
                };
                var pollSaved = await _pollService.Insert( poll );
                OkResponse( pollSaved );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpPut( "condominiums/{condominiumId}/polls/{pollId}" )]
        public async Task<IActionResult> UpdatePoll(int condominiumId, int pollId, [FromHeader] string Authotization, [FromBody] RequestPoll request)
        {
            try
            {
                var poll = await _pollService.GetById( pollId );
                if (poll == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }
                poll.Title = request.Title;
                poll.Description = request.Description;
                poll.StartDate = request.StartDate;
                poll.EndDate = request.EndDate;
                var pollSaved = await _pollService.Update( poll );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/polls/{pollId}" )]
        public async Task<IActionResult> DeletePoll(int condominiumId, int pollId, [FromHeader] string Authotization)
        {
            try
            {
                var poll = await _pollService.GetById( pollId );
                if (poll == null)
                {
                    NotFoundResponse();
                    return new ObjectResult(response);
                }
                poll.IsDelete = true;
                await _pollService.Update( poll );
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

        #region OPTION RESIDENT
        [HttpGet( "condominiums/{condominiumId}/polls/{pollId}/responses" )]
        public async Task<IActionResult> GetPollsResponseResident(int condominiumId, int pollId, [FromHeader] string Authotization)
        {
            try
            {
                var options = await _optionService.GetAllByPoll( pollId );
                var optionsId = options.Select( x => x.OptionId ).ToList();
                var optionsResidentes = await _optionResidentService.GetAllByPoll( optionsId );
                OkResponse( optionsResidentes );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }

        [HttpPost( "condominiums/{condominiumId}/polls/{pollId}/responses" )]
        public async Task<IActionResult> AddResponseResident(int condominiumId, int pollId, [FromHeader] string Authorization, [FromBody] RequestOptionResident request)
        {
            try
            {
                var resident = await _residentService.AuthToken( Authorization );
                if (resident == null)
                {
                    UnauthorizedResponse();
                    return new ObjectResult(response);
                }

                var optionResident = new OptionResident()
                {
                    Comment = request.Comment,
                    Date = DateTime.Now,
                    IsDelete = false,
                    OptionId = request.OptionId,
                    ResidentId = resident.ResidentId,
                    ResidentUserId = resident.UserId,
                };

                var optionResidentSaved = await _optionResidentService.Insert( optionResident );
                OkResponse( optionResidentSaved );
                return new ObjectResult(response);
            }
            catch (Exception e)
            {
                InternalServerErrorResponse( e.Message );
                return new ObjectResult(response);
            }
        }
        [HttpDelete( "condominiums/{condominiumId}/polls/{pollId}/responses/{responseId}" )]
        public async Task<IActionResult> DeleteResponseResident(int condominiumId, int pollId, int responseId, [FromHeader] string Authotization)
        {
            try
            {
                var optionResident = await _optionResidentService.GetById( responseId );
                optionResident.IsDelete = true;
                await _optionResidentService.Update( optionResident );
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
