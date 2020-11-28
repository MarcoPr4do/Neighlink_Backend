using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class Response
    {
        [JsonProperty( "status" )]
        public int Status { get; set; }
        [JsonProperty( "message" )]
        public string Message { get; set; }
        [JsonProperty( "result" )]
        public Object Result { get; set; }
    }
}
