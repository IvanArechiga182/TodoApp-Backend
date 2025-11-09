using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Application.Features.Tasks.GetTaskById
{
    internal class GetTaskByIdHandler : IRequestHandler<GetTaskByIdRequest, TaskOperationResponse>
    {
        private readonly AppDbContext _dbContext;

        public GetTaskByIdHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskOperationResponse> Handle(GetTaskByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _dbContext.tasks.FirstOrDefaultAsync(
                   t => t.Id == request.TaskId && t.UserId == request.UserId, cancellationToken);

                if (task == null)
                {
                    return new TaskOperationResponse
                    {
                        Status = 404,
                        Message = StatusMessages.Task.NotFound,
                        TrackId = Guid.NewGuid(),
                    };
                }

                return new TaskOperationResponse
                {
                    Status = 200,
                    Message = StatusMessages.Task.Founded,
                    TrackId = Guid.NewGuid(),
                    TasksList = [task]
                };
            }
            catch (Exception ex)
            {
                return new TaskOperationResponse
                {
                    Status = 500,
                    Message = $"Internal server error: {ex.Message}.",
                    TrackId = Guid.NewGuid()
                };
            }
        }
    }
}
