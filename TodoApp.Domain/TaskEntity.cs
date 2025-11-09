using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Domain;
[Table("Tasks")]

public class TaskEntity
{
    public int Id {  get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DueAt { get; set; }
    public UserEntity? User { get; set; } 
}



