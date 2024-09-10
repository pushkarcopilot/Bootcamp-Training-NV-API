using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Engagement>> GetAllEngagements()
        {
            if (_dbContext.Engagements == null)
            {
                return null; 
            }

            return await _dbContext.Engagements.ToListAsync();
        }
        public void AddEngagement(string clientName, DateTimeOffset auditStartDate, DateTimeOffset auditEndDate, int countryId, List<int> auditors, AuditTypeValue auditTypeId, EngagementStatusValue engagementStatusId)
        {
            var newEngagement = new Engagement()
            {
                ClientName = clientName,
                AuditStartDate = auditStartDate,
                AuditEndDate = auditEndDate,
                CountryId = countryId,
                Auditors = auditors,
                AuditTypeId = auditTypeId,
                StatusId = engagementStatusId,
            };

            _dbContext.Engagements.Add(newEngagement);

            _dbContext.SaveChanges();
        }
    }
}
