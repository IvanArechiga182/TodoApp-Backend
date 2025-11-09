using MediatR;

namespace TodoApp.Application.Features.Tasks
{
    public abstract class SingleTaskOperationRequest : IRequest<TaskOperationResponse>
    { 
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}
