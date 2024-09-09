using Bootcamp.Data.Models;

namespace Bootcamp.Data.Interface
{
    public interface IClientDetailsService
    {
        Task<LEV_Engagement> GetClientsDetailsAsync(int? ClientId);

        List<LEV_Countries> GetCountries();

        List<LEV_Auditors> GetAudiors();

        List<LEV_AuditStatus> GetAuditStatus();

        List<LEV_AuditTypes> GetAuditTypes();


    }
}
