using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{
    public class LEV_Engagement
    {
        [Key]
        public int? EngagementId { get; set; }
        public string? ClientName { get; set; }=String.Empty;
        public int? AuditTypeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int? StatusId { get; set; }
        public int? CountryId { get; set; }
        public int? AuditorsId { get; set; }
        public string AuditStatus { get; set; } = String.Empty;
        public string AuditorName { get; set; }=String.Empty;

        public string CountryName { get; set; } =String.Empty;
        public string AuditType { get; set; } =String.Empty;

        public int AccountNumber { get; set; }
        public int AccountCash { get; set; }
        public char AccountReceivable { get; set; }
        public int Inventoryint { get; set; }
        public int OtherExpenses { get; set; }
       






    


    }
}
