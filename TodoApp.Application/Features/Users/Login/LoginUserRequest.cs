
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApp.Application.Features.Users.Login
{
    public class LoginUserRequest : IRequest<AuthUserResponse>
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
