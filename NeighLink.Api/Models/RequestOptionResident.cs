using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestOptionResident
    {
        [JsonProperty( "comment" )]
        public String Comment { get; set; }
        [JsonProperty( "optionId" )]
        public int OptionId { get; set; }
    }
}
