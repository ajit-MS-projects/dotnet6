using System;
using System.Collections.Generic;

namespace EntityCoreDbFirst.Models
{
    public partial class Visit
    {
        public int VisitId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? VisitedAt { get; set; }
        public string? Phone { get; set; }
        public int StoreId { get; set; }
    }
}
