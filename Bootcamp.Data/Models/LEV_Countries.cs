using System.ComponentModel.DataAnnotations;


namespace Bootcamp.Data.Models
{
    public class LEV_Countries
    {
       [Key]
       public int CountryId { get; set; }
       public string CountryName { get; set; } = string.Empty;
       public int IsActive { get; set; }
    
    }
}
