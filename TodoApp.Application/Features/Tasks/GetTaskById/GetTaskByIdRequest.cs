using MediatR;

namespace TodoApp.Application.Features.Tasks.GetTaskById
{
    public class GetTaskByIdRequest  : SingleTaskOperationRequest, IRequest<TaskOperationResponse>
    {
    }
}
