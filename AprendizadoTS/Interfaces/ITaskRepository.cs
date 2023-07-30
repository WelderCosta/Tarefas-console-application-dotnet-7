using AprendizadoTS.Models;

namespace AprendizadoTS.Interfaces
{
    public interface ITaskRepository
    {
        void CreateTask(MTask task);
        void UpdateTask(MTask task);
        void DeleteTask(int id);
        MTask GetTask(int id);
    }
}
