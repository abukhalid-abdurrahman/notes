using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notes.Services.TasksService;
using TaskEntity = notes.Domains.Task;

namespace notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpPost]
        public async Task<TaskEntity> CreateTask(TaskEntity entity)
        {
            return await _tasksService.CreateTask(entity);
        }
    }
}