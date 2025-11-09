using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

namespace TodoApp.Application.Features.Tasks.EditTaskById
{
    internal class EditTaskByIdHandler : IRequestHandler<EditTaskByIdRequest, TaskOperationResponse>
    {
        private readonly AppDbContext _dbContext;
        public EditTaskByIdHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskOperationResponse> Handle(EditTaskByIdRequest request, CancellationToken cancellationToken)
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

                task.Title = request.Title;
                task.Description = request.Description;
                task.Status = request.Status;
                task.Priority = request.Priority;
                task.UpdatedAt = DateTime.UtcNow;
                task.DueAt = request.DueAt;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return new TaskOperationResponse
                {
                    Status = 200,
                    Message = StatusMessages.Task.Updated,
                    TrackId = Guid.NewGuid(),
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
