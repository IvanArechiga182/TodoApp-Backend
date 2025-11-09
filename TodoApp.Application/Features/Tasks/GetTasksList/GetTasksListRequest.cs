using MediatR;

namespace TodoApp.Application.Features.Tasks.GetTasksList
{
    public class GetTasksListRequest : IRequest<TaskOperationResponse>
    {
        public int UserId { get; set; }
    }
}
