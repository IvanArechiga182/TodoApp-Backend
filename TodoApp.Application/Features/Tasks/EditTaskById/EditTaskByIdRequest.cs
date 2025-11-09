using System.Text.Json.Serialization;
using TodoApp.Application.Features.Tasks.AddNewTask;

namespace TodoApp.Application.Features.Tasks.EditTaskById
{
    public class EditTaskByIdRequest : AddNewTaskRequest
    {
        [JsonIgnore]
        public new int UserId { get; set; }

        [JsonIgnore]
        public new DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public int TaskId { get; set; }
    }
}
