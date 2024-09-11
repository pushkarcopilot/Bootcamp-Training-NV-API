﻿using System.ComponentModel.DataAnnotations;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Models
{
    public class Engagement
    {
        public int EngagementId { get; set; }
        public string? ClientName { get; set; }
        public AuditTypeValue AuditTypeId { get; set; } // Enum for Audit Type
        public DateTimeOffset AuditStartDate { get; set; }
        public DateTimeOffset AuditEndDate { get; set; }
        public int CountryId { get; set; }
        public List<int>? Auditors { get; set; } // List of Auditor IDs
        public EngagementStatusValue StatusId { get; set; } // Enum for Status
    }
}