using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{
    public class DocumentDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileType { get; set; }
        [Required]
        public DateTime UploadedAt { get; set; }
        [Required]
        public byte[] DataContentVarbinary { get; set; }

    }
}
