using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotNetAuthSample.Api.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

       
        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
