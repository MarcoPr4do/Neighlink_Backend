using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Service;
using NeighLink.DateLayer.Service.Impls;

namespace NeighLink.Api.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IUserService _userService;

        public WeatherForecastController()
        {
            _userService = new UserServiceImpl( context );
        }


        private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range( 1, 5 ).Select( index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays( index ),
            //    TemperatureC = rng.Next( -20, 55 ),
            //    Summary = Summaries[ rng.Next( Summaries.Length ) ]
            //} )
            //.ToArray();
            var data = await _userService.List();
            return data;
        }
    }
}
