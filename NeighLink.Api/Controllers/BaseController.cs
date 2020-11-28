using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighLink.Api.Models;
using NeighLink.DateLayer.Models;

namespace NeighLink.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected neighlinkdbContext context = new neighlinkdbContext();
        protected Response response = new Response();

        protected void UnauthorizedResponse()
        {
            response.Status = ( int ) HttpStatusCode.Unauthorized;
            response.Message = "UNAUTHORIZED USER";
            response.Result = null;
        }

        protected void NotFoundResponse()
        {
            response.Status = ( int ) HttpStatusCode.NotFound;
            response.Message = "ENTITY NOT FOUND";
            response.Result = null;
        }

        protected void OkResponse(Object result)
        {
            response.Status = ( int ) HttpStatusCode.OK;
            response.Message = "SERVICE SUCCESS";
            response.Result = result;

        }

        protected void ConflictResponse(String message)
        {
            response.Status = ( int ) HttpStatusCode.Conflict;
            response.Message = message;
            response.Result = null;
        }

        protected void InternalServerErrorResponse(String message)
        {
            response.Status = ( int ) HttpStatusCode.InternalServerError;
            response.Message = $"Error => {message}";
        }

    }
}
