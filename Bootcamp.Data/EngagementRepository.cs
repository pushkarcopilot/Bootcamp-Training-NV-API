using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data
{
    public class EngagementRepository : IEngagementRepository
    {
        private readonly EngagementDbContext _dbContext;

        public EngagementRepository(EngagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AllEngagementsResponse> GetAllEngagements() =>
            from e in _dbContext.Engagements
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

        public void AddEngagement(string clientName, DateTimeOffset auditStartDate, DateTimeOffset auditEndDate, int countryId, List<int> auditors, AuditTypeId auditTypeId, EngagementStatusId engagementStatusId)
        {
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

            _dbContext.Engagements.Add(newEngagement);

            _dbContext.SaveChanges();
        }
    }
}
