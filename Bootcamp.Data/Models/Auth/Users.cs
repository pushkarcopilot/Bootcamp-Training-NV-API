using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bootcamp.Data.Models
{
    public class Users
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; init; }

        [JsonPropertyName("username")]
        public string UserName { get; init; } 
    }
}
