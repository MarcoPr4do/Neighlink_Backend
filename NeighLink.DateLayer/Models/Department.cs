using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? CondominiumId { get; set; }
        public string Code { get; set; }
        public int? LimitRegister { get; set; }
        public bool? IsDelete { get; set; }
        public int BuildingId { get; set; }
    }
}
