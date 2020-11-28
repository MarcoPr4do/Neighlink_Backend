using NeighLink.DateLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class ResponseLogin
    {
        [JsonProperty( "user" )]
        public Object User { get; set; }
        [JsonProperty( "userType" )]
        public String UserType { get; set; }
    }
}
