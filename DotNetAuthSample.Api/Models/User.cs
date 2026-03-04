using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DotNetAuthSample.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        
        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;

        
        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
