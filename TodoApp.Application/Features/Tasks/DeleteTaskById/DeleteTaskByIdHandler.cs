using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Application.Features.Tasks.DeleteTaskById
{
    internal class DeleteTaskByIdHandler : IRequestHandler<DeleteTaskByIdRequest, TaskOperationResponse>
    {
        private readonly AppDbContext _dbContext;
        public DeleteTaskByIdHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskOperationResponse> Handle(DeleteTaskByIdRequest request, CancellationToken cancellationToken)
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
                        TrackId = Guid.NewGuid()
                    };
                }

                _dbContext.tasks.Remove(task);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new TaskOperationResponse
                {
                    Status = 200,
                    Message = StatusMessages.Task.Deleted,
                    TrackId = Guid.NewGuid()
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
