using Bootcamp.Data.Context;
using Bootcamp.Data.Interface;
using Bootcamp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Bootcamp.Data.Implementation
{
    public class ClientDetailsService : IClientDetailsService
    {
        private readonly Auditcontext _Auditcontext;

        public ClientDetailsService(Auditcontext Auditcontext)
        {
            _Auditcontext = Auditcontext;

        }

        public async Task<LEV_Engagement> GetClientsDetailsAsync(int? EngagemententId)
        {
            var result = await Task.Run(() => (from Engagement in _Auditcontext.LEV_Engagement
                                               join AuditStatus in _Auditcontext.LEV_AuditStatus on Engagement.StatusId equals AuditStatus.AuditStatusId
                                               join Auditors in _Auditcontext.LEV_Auditors on Engagement.AuditorsId equals Auditors.AuditorsId
                                               join Country in _Auditcontext.LEV_Countries on Engagement.CountryId equals Country.CountryId
                                               join AuditorsType in _Auditcontext.LEV_AuditTypes on Engagement.AuditTypeId equals AuditorsType.AuditTypeId
                                               join Account in _Auditcontext.LEV_Accounts on Engagement.EngagementId equals Account.EngagementId
                                               where Engagement.EngagementId == EngagemententId
                                               select new LEV_Engagement()
                                               {
                                                   EngagementId = Engagement.EngagementId,
                                                   AuditorsId = Auditors.AuditorsId,
                                                   StatusId = AuditStatus.AuditStatusId,
                                                   AuditTypeId = AuditorsType.AuditTypeId,
                                                   CountryId = Engagement.CountryId,
                                                   StartDate = Engagement.StartDate,
                                                   EndDate = Engagement.EndDate,
                                                   ClientName = Engagement.ClientName,
                                                   AuditStatus = AuditStatus.AuditStatus,
                                                   AuditorName = Auditors.AuditorsName,
                                                   CountryName = Country.CountryName,
                                                   AuditType = AuditorsType.AuditType,
                                                   AccountNumber = Account.AccountNumber,
                                                   AccountCash = Account.AccountCash,
                                                   AccountReceivable = Account.AccountReceivable,
                                                   OtherExpenses = Account.OtherExpenses,
                                                   Inventoryint = Account.Inventoryint


                                               }).FirstOrDefault());


            //var result = await Task.Run(()=>_Auditcontext.LEV_Engagement.Where(s => s.EngagementId == EngagemententId).FirstOrDefault<LEV_Engagement>());
            return result;
        }

        public List<LEV_Countries> GetCountries()
        {
            var result = new List<LEV_Countries>();
            result = (from Country in _Auditcontext.LEV_Countries
                      where Country.IsActive == 1
                      select new LEV_Countries()
                      {
                          CountryId = Country.CountryId,
                          CountryName = Country.CountryName,
                      }).ToList();
            return result;
        }


        public List<LEV_Auditors> GetAudiors()
        {
            var result = new List<LEV_Auditors>();
            result = (from auditor in _Auditcontext.LEV_Auditors
                      where auditor.IsActive == 1
                      select new LEV_Auditors()
                      {
                          AuditorsId = auditor.AuditorsId,
                          AuditorsName = auditor.AuditorsName,
                      }).ToList();
            return result;
        }


        public List<LEV_AuditStatus> GetAuditStatus()
        {
            var result = new List<LEV_AuditStatus>();
            result = (from auditorstatus in _Auditcontext.LEV_AuditStatus
                      where auditorstatus.IsActive == 1
                      select new LEV_AuditStatus()
                      {
                          AuditStatusId = auditorstatus.AuditStatusId,
                          AuditStatus = auditorstatus.AuditStatus,
                      }).ToList();
            return result;
        }



        public List<LEV_AuditTypes> GetAuditTypes()
        {
            var result = new List<LEV_AuditTypes>();
            result = (from audittype in _Auditcontext.LEV_AuditTypes
                      where audittype.IsActive == 1
                      select new LEV_AuditTypes()
                      {
                          AuditTypeId = audittype.AuditTypeId,
                          AuditType = audittype.AuditType,
                      }).ToList();
            return result;
        }

    }
}
