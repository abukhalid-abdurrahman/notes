using System;
using notes.DataAccess;
using notes.DataAccess.Repositories.GenericRepository;
using notes.Domains;

namespace notes.Services.TasksService
{
    public class TasksService : ITasksService
    {
        private readonly IGenericRepository<Task> _repository;
        public TasksService(NotesContext context)
        {
            _repository = new GenericRepository<Task>(context);
        }
        
        public async System.Threading.Tasks.Task<Task> CreateTask(Task entity)
        {
            if (entity == null)
                return null;

            if (string.IsNullOrEmpty(entity.Tasktext))
                return null;

            entity.Removed = false;
            entity.Timestamp = DateTime.Now;
            return await _repository.CreateAsync(entity);
        }
    }
}