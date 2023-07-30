using AprendizadoTS.Data;
using AprendizadoTS.Controllers;
using AprendizadoTS.Repositories;
using AprendizadoTS.Services;
using Microsoft.EntityFrameworkCore;
using AprendizadoTS.Models;

namespace AprendizadoTS
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextData>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-THJUGI2\\SQLEXPRESS;Initial Catalog=DB_AprendizadoTS;User ID=sa;Password=admin123;Encrypt=False");

            using (var context = new DbContextData(optionsBuilder.Options))
            {
                var taskRepository = new TaskRepository(context);
                var taskService = new TaskService(taskRepository);
                var taskController = new TaskController(taskService);

                var task = new MTask
                {
                    Id = 1,
                    Name = "Minha tarefa testando update",
                    Description = "Esta é minha tarefa testando update",
                    IsCompleted = false,
                };

                taskController.UpdateTask(task);
            }
        }
    }
}