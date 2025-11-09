using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Features.Tasks.GetTaskById
{
    public class GetTaskByIdRequest  : SingleTaskOperationRequest, IRequest<TaskOperationResponse>
    {
    }
}
