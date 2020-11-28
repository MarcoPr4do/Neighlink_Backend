using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighLink.Api.Models
{
    public class RequestPayment
    {
        [JsonProperty( "id" )]
        public int Id { get; set; }
        [JsonProperty( "paymentDate" )]
        public DateTime PaymentDate { get; set; }
        [JsonProperty( "amount" )]
        public decimal Amount { get; set; }
        [JsonProperty( "confirmPaid" )]
        public bool ConfirmPaid { get; set; }
        [JsonProperty( "residentId" )]
        public int ResidentId { get; set; }
        [JsonProperty( "urlImage" )]
        public string UrlImage { get; set; }
    }
}
