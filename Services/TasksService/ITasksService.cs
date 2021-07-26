using System.Threading.Tasks;
using TaskEntity = notes.Domains.Task;

namespace notes.Services.TasksService
{
    public interface ITasksService
    {
        Task<TaskEntity> CreateTask(TaskEntity entity);
    }
}