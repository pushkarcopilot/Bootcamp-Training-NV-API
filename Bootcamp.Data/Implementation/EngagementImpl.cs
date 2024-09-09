using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Implementation
{
    public class EngagementImpl : IEngagementRepository
    {
        void IEngagementRepository.AddEngagement(string clientName, DateTimeOffset auditStartDate, DateTimeOffset auditEndDate, int countryId, List<int> auditors, AuditTypeId auditTypeId, EngagementStatusId engagementStatusId)
        {
            using var context = new EngagementDbContext();

            var newEngagement = new Engagement()
            {
                ClientName = clientName,
                AuditStartDate = auditStartDate,
                AuditEndDate = auditEndDate,
                CountryId = countryId,
                Auditors = auditors,
                AuditTypeId = auditTypeId,
                EngagementStatusId = engagementStatusId,
            };

            context.Engagements.Add(newEngagement);

            context.SaveChanges();
        }

        IQueryable<AllEngagementsResponse> IEngagementRepository.GetAllEngagements()
        {
            using var context = new EngagementDbContext();

            var engagements = from e in context.Engagements
                              select new AllEngagementsResponse
                              {
                                  Id = e.EngagementId,
                                  ClientName = e.ClientName,
                                  AuditType = e.AuditType.Name,
                                  EngagementStatus = e.EngagementStatus.Name,
                                  StartDate = e.AuditStartDate,
                                  EndDate = e.AuditEndDate,
                                  CountryId = e.CountryId
                              };

            return engagements;
        }
    }

    
}
