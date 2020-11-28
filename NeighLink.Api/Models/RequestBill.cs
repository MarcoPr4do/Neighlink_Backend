using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestBill
    {
        [JsonProperty( "name" )]
        public string Name { get; set; }
        [JsonProperty( "description" )]
        public string Description { get; set; }
        [JsonProperty( "amount" )]
        public decimal Amount { get; set; }
        [JsonProperty( "startDate" )]
        public DateTime StartDate { get; set; }
        [JsonProperty( "endDate" )]
        public DateTime EndDate { get; set; }
        [JsonProperty( "paymentCategoryId" )]
        public int PaymentCategoryId { get; set; }
    }
}
