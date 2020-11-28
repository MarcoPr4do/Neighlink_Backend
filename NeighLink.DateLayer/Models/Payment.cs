using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public bool ConfirmPaid { get; set; }
        public int BillId { get; set; }
        public int ResidentId { get; set; }
        public int ResidentUserId { get; set; }
        public string UrlImage { get; set; }
    }
}
