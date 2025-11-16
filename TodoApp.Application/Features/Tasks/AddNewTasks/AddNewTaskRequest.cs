using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using TodoApp.Domain;
namespace TodoApp.Application.Features.Tasks.AddNewTask
{
    public class AddNewTaskRequest : IRequest<TaskOperationResponse>
    {
        [Required]
        [JsonIgnore]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }  = string.Empty;

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public Status Status { get; set; } = Status.JustCreated;

        [Required]
        [JsonPropertyName("priority")]
        public Priority Priority {  get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        //[JsonPropertyName("updatedAt")]
        //[JsonIgnore]
        //public DateTime? UpdatedAt { get; set; }

        [Required]
        [JsonPropertyName("dueAt")]
        public DateTime DueAt { get; set; }

    }
}
