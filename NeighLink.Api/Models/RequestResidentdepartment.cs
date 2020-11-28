using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestResidentdepartment
    {
        [JsonProperty( "email" )]
        public string Code { get; set; }
    }
}
