using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestResident
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }
        [JsonProperty( "lastname" )]
        public string LastName { get; set; }
        [JsonProperty( "birthDate" )]
        public DateTime BirthDate { get; set; }
        [JsonProperty( "phone" )]
        public string Phone { get; set; }
        [JsonProperty( "gender" )]
        public string Gender { get; set; }
        [JsonProperty( "email" )]
        public string Email { get; set; }
        [JsonProperty( "password" )]
        public string Password { get; set; }
    }
}
