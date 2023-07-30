using AprendizadoTS.Interfaces;
using AprendizadoTS.Models;

namespace AprendizadoTS.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(MTask task)
        {
            if(task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _taskRepository.CreateTask(task);
        }

        public void UpdateTask(MTask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            MTask existingTask = _taskRepository.GetTask(task.Id);

            if (existingTask == null) 
            {
                throw new ArgumentNullException("Task not found");
            }

            existingTask.Name = task.Name;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            _taskRepository.UpdateTask(existingTask);
        }

        public void DeleteTask(int id)
        {
            _ = _taskRepository.GetTask(id) ?? throw new ArgumentNullException("Task not found");

            _taskRepository.DeleteTask(id);
        }

        public MTask GetTask(int id)
        {
            return _taskRepository.GetTask(id);
        }
    }
}
