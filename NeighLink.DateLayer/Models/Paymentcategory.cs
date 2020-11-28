using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Paymentcategory
    {
        public int PaymentCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; }
        public int? CondominiumId { get; set; }
    }
}
