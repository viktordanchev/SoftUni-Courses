using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskManager;

namespace TaskManager.Tests
{
    public class CorrectnessTests
    {
        private IManager taskManager;
        
        [SetUp]
        public void Setup()
        {
            this.taskManager = new Manager();
        }
        
        [Test]
        public void AddTask_ShouldAddTaskToTheSystem()
        {
            // Arrange
            var task = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = GetNextId(),
            };
            
            // Act
            this.taskManager.AddTask(task);
            
            // Assert
            Assert.True(this.taskManager.Contains(task.Id));
            Assert.That(this.taskManager.Size(), Is.EqualTo(1));
            Assert.That(this.taskManager.Get(task.Id), Is.EqualTo(task));
        }
        
        [Test]
        public void Contains_ShouldReturnFalse_WhenTaskIdDoesNotExist()
        {
            // Arrange
            var task = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = GetNextId(),
            };
            
            // Act
            this.taskManager.AddTask(task);
            
            // Assert
            Assert.False(this.taskManager.Contains(GetNextId()));
        }

        [Test]
        public void Size_ReturnsNumberOfTasksInTheSystem()
        {
            // Arrange
            var count = 42;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Assignee = "John",
                    Priority = 1,
                    Title = GetNextId(),
                };

                this.taskManager.AddTask(task);
            }
            
            // Act
            var result = this.taskManager.Size();
            
            // Assert
            Assert.That(result, Is.EqualTo(count));
        }
        
        [Test]
        public void RemoveTask_RemovesTheTaskFromTheSystem_WhenIdExists()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = GetNextId(),
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 2,
                Title = GetNextId(),
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.RemoveTask(task1.Id);
            
            // Assert
            Assert.False(this.taskManager.Contains(task1.Id));
            Assert.That(this.taskManager.Size(), Is.EqualTo(1));
            Assert.Throws<ArgumentException>(
                () => this.taskManager.Get(task1.Id));
        }
        
        [Test]
        public void AddDependency_ShouldAddIndirectDependencies()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };
            
            var task3 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.AddTask(task3);
            
            this.taskManager.AddDependency(task1.Id, task2.Id);
            this.taskManager.AddDependency(task2.Id, task3.Id);

            // Assert
            Assert.That(
                this.taskManager.GetDependencies(task1.Id).OrderBy(t => t.Title),
                Is.EquivalentTo(new List<Task> { task2, task3 }));
            
            Assert.That(
                this.taskManager.GetDependents(task1.Id),
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependencies(task2.Id),
                Is.EquivalentTo(new List<Task> { task3 }));
            
            Assert.That(
                this.taskManager.GetDependents(task2.Id),
                Is.EquivalentTo(new List<Task> { task1 }));
            
            Assert.That(
                this.taskManager.GetDependencies(task3.Id),
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependents(task3.Id).OrderBy(t => t.Title),
                Is.EquivalentTo(new List<Task>{ task1, task2 }));
        }
        
        [Test]
        public void GetDependencies_ShouldReturnAllDependenciesThatTaskHave()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };
            
            var task3 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.AddTask(task3);
            
            this.taskManager.AddDependency(task1.Id, task2.Id);
            this.taskManager.AddDependency(task1.Id, task3.Id);

            // Assert
            Assert.That(
                this.taskManager.GetDependencies(task1.Id), 
                Is.EquivalentTo(new List<Task> { task2, task3 }));

            // Assert
            Assert.That(
                this.taskManager.GetDependencies(task2.Id), 
                Is.EquivalentTo(new List<Task>()));

            // Assert
            Assert.That(
                this.taskManager.GetDependencies(task3.Id), 
                Is.EquivalentTo(new List<Task>()));
        }
        
        [Test]
        public void GetDependent_ShouldReturnAllTasksThatDependsOnTaskId()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };
            
            var task3 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.AddTask(task3);
            
            this.taskManager.AddDependency(task1.Id, task2.Id);
            this.taskManager.AddDependency(task1.Id, task3.Id);

            // Assert
            Assert.That(
                this.taskManager.GetDependents(task1.Id), 
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependents(task2.Id), 
                Is.EquivalentTo(new List<Task> { task1 }));
            
            Assert.That(
                this.taskManager.GetDependents(task3.Id), 
                Is.EquivalentTo(new List<Task> { task1 }));
        }
        
        [Test]
        public void RemoveTask_ShouldUpdateDependencies()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };
            
            var task3 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            
            var task4 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task4",
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.AddTask(task3);
            this.taskManager.AddTask(task4);
            
            this.taskManager.AddDependency(task1.Id, task2.Id);
            this.taskManager.AddDependency(task1.Id, task3.Id);
            this.taskManager.AddDependency(task2.Id, task4.Id);
            
            this.taskManager.RemoveTask(task3.Id);

            // Assert
            // Task1
            Assert.That(
                this.taskManager.GetDependencies(task1.Id), 
                Is.EquivalentTo(new List<Task> { task2, task4 }));
            Assert.That(
                this.taskManager.GetDependents(task1.Id), 
                Is.EquivalentTo(new List<Task>()));

            // Task2
            Assert.That(
                this.taskManager.GetDependencies(task2.Id), 
                Is.EquivalentTo(new List<Task> { task4 }));
            Assert.That(
                this.taskManager.GetDependents(task2.Id), 
                Is.EquivalentTo(new List<Task> { task1 }));
            
            // Task3
            Assert.That(
                this.taskManager.GetDependencies(task3.Id), 
                Is.EquivalentTo(new List<Task>()));
            Assert.That(
                this.taskManager.GetDependents(task3.Id), 
                Is.EquivalentTo(new List<Task>()));
            
            // Task4
            Assert.That(
                this.taskManager.GetDependencies(task4.Id), 
                Is.EquivalentTo(new List<Task>()));
            Assert.That(
                this.taskManager.GetDependents(task4.Id).OrderBy(t => t.Title), 
                Is.EquivalentTo(new List<Task> { task1, task2 }));
        }
        
        [Test]
        public void RemoveDependency_ShouldUpdateTasksDependencies()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };
            
            var task3 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            
            var task4 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task4",
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.AddTask(task3);
            this.taskManager.AddTask(task4);
            
            this.taskManager.AddDependency(task1.Id, task2.Id);
            this.taskManager.AddDependency(task1.Id, task3.Id);
            this.taskManager.AddDependency(task2.Id, task4.Id);

            this.taskManager.RemoveDependency(task1.Id, task3.Id);
            
            // Assert
            // Task1
            Assert.That(
                this.taskManager.GetDependencies(task1.Id),
                Is.EquivalentTo(new List<Task> { task2, task4 }));
            
            Assert.That(
                this.taskManager.GetDependents(task1.Id),
                Is.EquivalentTo(new List<Task>()));
            
            // Task2
            Assert.That(
                this.taskManager.GetDependencies(task2.Id),
                Is.EquivalentTo(new List<Task> { task4 }));
            
            Assert.That(
                this.taskManager.GetDependents(task2.Id),
                Is.EquivalentTo(new List<Task> { task1 }));
            
            // Task3
            Assert.That(
                this.taskManager.GetDependencies(task3.Id),
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependents(task3.Id),
                Is.EquivalentTo(new List<Task>()));
            
            // Task4
            Assert.That(
                this.taskManager.GetDependencies(task4.Id),
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependents(task4.Id).OrderBy(t => t.Title),
                Is.EquivalentTo(new List<Task> { task1, task2 }));
        }
        
        [Test]
        public void RemoveDependency_ShouldUpdateTasksDependencies_WhenIdirectDepencyIsRemoved()
        {
            // Arrange
            var task1 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task1",
            };
            
            var task2 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task2",
            };
            
            var task3 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task3",
            };
            
            var task4 = new Task
            {
                Id = GetNextId(),
                Assignee = "John",
                Priority = 1,
                Title = "Task4",
            };
            
            // Act
            this.taskManager.AddTask(task1);
            this.taskManager.AddTask(task2);
            this.taskManager.AddTask(task3);
            this.taskManager.AddTask(task4);
            
            this.taskManager.AddDependency(task1.Id, task2.Id);
            this.taskManager.AddDependency(task2.Id, task3.Id);
            this.taskManager.AddDependency(task4.Id, task1.Id);

            this.taskManager.RemoveDependency(task2.Id, task3.Id);
            
            // Assert
            Assert.That(
                this.taskManager.GetDependencies(task1.Id),
                Is.EquivalentTo(new List<Task> { task2 }));
            Assert.That(
                this.taskManager.GetDependents(task1.Id),
                Is.EquivalentTo(new List<Task> { task4 }));
            
            Assert.That(
                this.taskManager.GetDependencies(task2.Id),
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependents(task2.Id).OrderBy(t => t.Title),
                Is.EquivalentTo(new List<Task> { task1, task4 }));
            
            Assert.That(
                this.taskManager.GetDependencies(task3.Id),
                Is.EquivalentTo(new List<Task>()));
            
            Assert.That(
                this.taskManager.GetDependents(task3.Id),
                Is.EquivalentTo(new List<Task>()));

            Assert.That(
                this.taskManager.GetDependencies(task4.Id).OrderBy(t => t.Title),
                Is.EquivalentTo(new List<Task> { task1, task2 }));

            Assert.That(
                this.taskManager.GetDependents(task4.Id),
                Is.EquivalentTo(new List<Task>()));
        }

        private static string GetNextId()
            => Guid.NewGuid().ToString();
    }
}
