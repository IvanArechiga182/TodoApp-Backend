using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TodoApp.Application.Features.Users
{
    public class AuthUserResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("trackId")]
        public Guid TrackId { get; set; } = Guid.Empty;
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
