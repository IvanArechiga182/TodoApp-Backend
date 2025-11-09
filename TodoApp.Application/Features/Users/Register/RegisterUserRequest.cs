using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApp.Application.Features.Users.Register
{
    public class RegisterUserRequest: IRequest<AuthUserResponse>
    {
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
