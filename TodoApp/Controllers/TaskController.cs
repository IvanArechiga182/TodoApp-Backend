using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Tasks.AddNewTask;
using TodoApp.Application.Features.Tasks.DeleteTaskById;
using TodoApp.Application.Features.Tasks.EditTaskById;
using TodoApp.Application.Features.Tasks.GetTaskById;
using TodoApp.Application.Features.Tasks.GetTasksList;

namespace TodoApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IMediator _mediator;

        public TaskController(ILogger<TaskController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("GetDataMock/{id}")]
        public IActionResult Get()
        {
            string result = "Test realizado correctamente";
            return Ok(result);
        }

        [HttpPost("CreateNewTask/{userId}")]
        public async Task<IActionResult> CreateNewTask([FromBody] AddNewTaskRequest request, [FromRoute] int userId)
        {
            var result = await _mediator.Send(new AddNewTaskRequest
            {
                UserId = userId,
                Title = request.Title,
                Description = request.Description,
                Priority = request.Priority,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt,
                DueAt = request.DueAt,
            });
            return StatusCode(result.Status, result);
        }

        [HttpGet("GetTaskById/{userId}/{taskId}")]
        public async Task<IActionResult> GetTaskById([FromRoute] int userId, [FromRoute] int taskId)
        {
            var result = await _mediator.Send(new GetTaskByIdRequest
            {
                UserId = userId,
                TaskId = taskId
            });
            return StatusCode(result.Status, result);
        }

        [HttpGet("GetTasksList/{userId}")]
        public async Task<IActionResult> GetUserTasksList([FromRoute] int userId)
        {
            var result = await _mediator.Send(new GetTasksListRequest { UserId = userId });
            return StatusCode(result.Status, result);
        }

        [HttpPut("EditTaskById/{userId}/{taskId}")]
        public async Task<IActionResult> EditTaskById([FromRoute] int userId, [FromRoute] int taskId,
            [FromBody] EditTaskByIdRequest request)
        {
            request.TaskId = taskId;
            request.UserId = userId;

            var result = await _mediator.Send(request);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("DeleteTaskById/{userId}/{taskId}")]
        public async Task<IActionResult> DeleteTaskById([FromRoute] int userId, 
            [FromRoute] int taskId)
        {
            var result = await _mediator.Send(new DeleteTaskByIdRequest
            {
                UserId = userId,
                TaskId = taskId
            });
            return StatusCode(result.Status, result);
        }
        

    }
}
