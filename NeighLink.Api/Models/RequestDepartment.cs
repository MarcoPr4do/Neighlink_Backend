using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestDepartment
    {
        [JsonProperty( "id" )]
        public int Id { get; set; } = 0;
        [JsonProperty( "name" )]
        public String Name { get; set; }
        [JsonProperty( "limitRegister" )]
        public int? LimitRegister { get; set; }
    }
}
