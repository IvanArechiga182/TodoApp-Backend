using MediatR;
using TodoApp.Data;
using TodoApp.Domain;

namespace TodoApp.Application.Features.Tasks.AddNewTask
{
    internal class AddNewTaskHandler : IRequestHandler<AddNewTaskRequest, TaskOperationResponse>
    {
        private readonly AppDbContext _dbContext;
        public AddNewTaskHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskOperationResponse> Handle(AddNewTaskRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var taskEntity = new TaskEntity
                {
                    Title = request.Title,
                    UserId = request.UserId,
                    Description = request.Description,
                    CreatedAt = request.CreatedAt,
                    Priority = request.Priority,
                    UpdatedAt = request.UpdatedAt,
                    DueAt = request.DueAt,
                };

                await _dbContext.AddAsync(taskEntity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return new TaskOperationResponse
                {
                    Status = 200,
                    Message = $"Task '{taskEntity.Title}' has been created successfully.",
                    TrackId = Guid.NewGuid(),
                };
            }
            catch (Exception ex) 
            {
                return new TaskOperationResponse
                {
                    Status = 500,
                    Message = $"Internal server error: {ex.Message}",
                    TrackId = Guid.NewGuid()
                };
            }
        }
    }
}
