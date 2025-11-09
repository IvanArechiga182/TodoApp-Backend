using System.Text.Json.Serialization;
using TodoApp.Domain;

namespace TodoApp.Application.Features.Tasks
{
    public class TaskOperationResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("trackId")]
        public Guid TrackId { get; set; } = Guid.Empty;

        [JsonPropertyName("tasksList")]
        public List<TaskEntity>? TasksList { get; set; } = [];
    }
}
