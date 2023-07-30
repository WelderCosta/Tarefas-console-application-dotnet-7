using AprendizadoTS.Data;
using AprendizadoTS.Interfaces;
using AprendizadoTS.Models;

namespace AprendizadoTS.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContextData _context;
        
        public TaskRepository(DbContextData context)
        {
            _context = context;
        }

        public void CreateTask(MTask task)
        {
            _context.MTask.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(MTask task)
        {
            _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = _context.MTask.Find(id);
            if (taskToDelete != null)
            {
                _context.Remove(taskToDelete);
                _context.SaveChanges();
            }
        }

        public MTask GetTask(int id)
        {
            return _context.MTask.FirstOrDefault(t => t.Id == id);
        }
    }
}
