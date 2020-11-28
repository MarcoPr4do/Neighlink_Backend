using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDelete { get; set; }
        public int? AdministratorId { get; set; }
        public int DepartmentId { get; set; }
        public int PaymentCategoryId { get; set; }
        public int? CondominiumId { get; set; }
    }
}
