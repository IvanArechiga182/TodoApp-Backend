using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Application.Features.Tasks.GetTasksList
{
    internal class GetTasksListHandler : IRequestHandler<GetTasksListRequest, TaskOperationResponse>
    {
        private readonly AppDbContext _dbContext;
        public GetTasksListHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskOperationResponse> Handle(GetTasksListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var tasks = await _dbContext.tasks.Where(
                    t => t.UserId == request.UserId).ToListAsync(cancellationToken);

                var message = tasks.Any()
                    ? StatusMessages.Task.TaskListFounded
                    : StatusMessages.Task.NotFoundedTasksList;

                return new TaskOperationResponse
                {
                    Status = 200,
                    Message = message,
                    TasksList = tasks,
                    TrackId = Guid.NewGuid(),
                };
            }
            catch (Exception ex)
            {
                return new TaskOperationResponse
                {
                    Status = 500,
                    Message = $"Internal server error: {ex.Message}",
                    TrackId = Guid.NewGuid(),
                };

            }

        }
    }
}
