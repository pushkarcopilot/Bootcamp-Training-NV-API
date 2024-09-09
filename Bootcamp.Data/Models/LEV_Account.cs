using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{
    public class LEV_Account
    {
        [Key]
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public int AccountCash { get; set; }
        public char AccountReceivable { get; set; }
        public int Inventoryint { get; set; }
        public int OtherExpenses { get; set; }
        public int? EngagementId { get;set;}    

    }
}
