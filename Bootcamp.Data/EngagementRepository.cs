using AutoMapper;
using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                //AuditType = e.AuditType.Name,
                // EngagementStatus = e.EngagementStatus.Name,
                AuditType = e.AuditTypeId.ToString(),
                EngagementStatus = e.EngagementStatusId.ToString(),
                StartDate = e.AuditStartDate,
                EndDate = e.AuditEndDate,
                CountryId = e.CountryId
            };

        public void AddEngagement(Engagement data)
        {              
            _dbContext.Add(data);
            _dbContext.SaveChanges();
        }
    }
}
