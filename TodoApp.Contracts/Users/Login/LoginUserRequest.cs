using System.Text.Json;
using System.Text.Json.Serialization;

namespace TodoApp.Contracts.Users.Login
{
    public class LoginUserRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; }= string.Empty;

    }
}
