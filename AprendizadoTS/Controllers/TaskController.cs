using AprendizadoTS.Interfaces;
using AprendizadoTS.Models;

namespace AprendizadoTS.Controllers
{
    public class TaskController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void CreateTask(MTask task)
        {
            _taskService.CreateTask(task);
        }

        public void UpdateTask(MTask task)
        {
            _taskService.UpdateTask(task);
        }
    }
}
