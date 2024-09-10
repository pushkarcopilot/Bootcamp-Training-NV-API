using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp.Data.Models
{
    public class EngagementSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SettingId { get; set; }

        [Required]
        [StringLength(64)]
        public string KeyName { get; set; }

        [Required]
        [StringLength(64)]
        public string DataType { get; set; }

        public long? ValueBigInt { get; set; }
        public decimal? ValueNumeric { get; set; }
        public short? ValueSmallInt { get; set; }
        public decimal? ValueDecimal { get; set; }
        public decimal? ValueSmallMoney { get; set; }
        public int? ValueInt { get; set; }
        public byte? ValueTinyInt { get; set; }
        public decimal? ValueMoney { get; set; }
        public float? ValueFloat { get; set; }
        public float? ValueReal { get; set; }
        public DateTime? ValueDate { get; set; }
        public DateTimeOffset? ValueDateTimeOffSet { get; set; }
        public DateTime? ValueDateTime2 { get; set; }
        public DateTime? ValueSmallDateTime { get; set; }
        public DateTime? ValueDateTime { get; set; }
        public TimeSpan? ValueTime { get; set; }
        [StringLength(1024)]
        public string? ValueVarChar { get; set; }
        [StringLength(1)]
        public string? ValueChar { get; set; }

        [Required]
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string InsertedBy { get; set; } = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string LastUpdatedBy { get; set; } = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    }
}
