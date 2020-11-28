using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestAuth
    {
        [JsonProperty( "email" )]
        public String Email { get; set; }
        [JsonProperty( "password" )]
        public String Password { get; set; }
    }
}
