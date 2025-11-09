using System.Text.Json.Serialization;
using TodoApp.Domain;

namespace TodoApp.Contracts.Tasks
{
    public class AddNewTaskRequest
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("priority")]
        public Priority Priority { get; set; }
        
    }
}
