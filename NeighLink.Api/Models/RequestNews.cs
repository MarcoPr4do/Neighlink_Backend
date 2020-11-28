using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestNews
    {
        [JsonProperty( "title" )]
        public String Title { get; set; }
        [JsonProperty( "description" )]
        public String Description { get; set; }
    }
}
