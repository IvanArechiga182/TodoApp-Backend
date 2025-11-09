using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Domain;
[Table("Users")]

public class UserEntity
{
    public int Id {  get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } =string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool IsActiveUser { get; set; }
    public ICollection<TaskEntity>? Tasks { get; set; }
}
