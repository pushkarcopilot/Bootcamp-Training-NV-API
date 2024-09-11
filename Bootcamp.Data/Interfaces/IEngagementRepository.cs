﻿using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Interfaces
{
    public interface IEngagementRepository
    {
        Task<IEnumerable<Engagement>> GetAllEngagements();

        Task<IEnumerable<Engagement>> GetEngagementById(int engagementId);
        void AddEngagement(string clientName, DateTimeOffset auditStartDate, DateTimeOffset auditEndDate, int countryId, List<int> auditors, AuditTypeValue auditTypeId, EngagementStatusValue engagementStatusId);
    }
}
