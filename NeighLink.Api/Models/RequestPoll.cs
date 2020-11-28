using NeighLink.DateLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestPoll
    {
        [JsonProperty( "title" )]
        public String Title { get; set; }
        [JsonProperty( "description" )]
        public String Description { get; set; }
        [JsonProperty( "startDate" )]
        public DateTime StartDate { get; set; }
        [JsonProperty( "endDate" )]
        public DateTime EndDate { get; set; }
        [JsonProperty( "options" )]
        public List<Option> Options { get; set; }
    }
}
