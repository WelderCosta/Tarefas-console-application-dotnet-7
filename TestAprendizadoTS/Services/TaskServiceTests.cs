using AprendizadoTS.Interfaces;
using AprendizadoTS.Models;
using AprendizadoTS.Services;
using Moq;
using Xunit;

namespace TestAprendizadoTS.Services
{
    public class TaskServiceTest
    {
        [Fact]
        public void CreateTask_ShouldCallRepository()
        {
            // Arrange
            var task = new MTask{Name = "Test Create task"};
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.CreateTask(It.IsAny<MTask>())).Verifiable();
            var taskService = new TaskService(mockRepo.Object);

            // Act
            taskService.CreateTask(task);

            // Assert
            mockRepo.Verify();
        }

        [Fact]
        public void UpdateTask_UpdatesTaskInRepository()
        {
            // Arrange
            var taskToUpdate = new MTask { Id = 1, Name = "Test 2 Update task", IsCompleted = false };
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(x => x.GetTask(It.IsAny<int>())).Returns(taskToUpdate);
            var taskService = new TaskService(mockRepo.Object);

            // Act
            taskService.UpdateTask(taskToUpdate);

            // Assert
            mockRepo.Verify(x => x.UpdateTask(It.IsAny<MTask>()), Times.Once);
        }

        [Fact]
        public void DeleteTask_DeletesTaskInRepository()
        {
            // Arrange
            var taskToDelete = new MTask { Id = 1 };
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(x => x.GetTask(It.IsAny<int>())).Returns(taskToDelete);
            var taskService = new TaskService(mockRepo.Object);

            // Act
            taskService.DeleteTask(taskToDelete.Id);

            // Assert
            mockRepo.Verify(x => x.DeleteTask(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetTask_GetTaskInRepository()
        {
            // Arrange
            var taskToGet = new MTask { Id = 2 };
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(x => x.GetTask(It.IsAny<int>())).Returns(taskToGet);
            var taskService = new TaskService(mockRepo.Object);

            // Act
            var retrievedTask = taskService.GetTask(taskToGet.Id);

            // Assert
            mockRepo.Verify(x => x.GetTask(taskToGet.Id), Times.Once);
            Assert.Equal(taskToGet, retrievedTask);
        }
    }
}
