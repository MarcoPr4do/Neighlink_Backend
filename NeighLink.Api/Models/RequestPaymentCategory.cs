using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestPaymentCategory
    {
        [JsonProperty( "name" )]
        public String Name { get; set; }
        [JsonProperty( "description" )]
        public String Description { get; set; }
    }
}
