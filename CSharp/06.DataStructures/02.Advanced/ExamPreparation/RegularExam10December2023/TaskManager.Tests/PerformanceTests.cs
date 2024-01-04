using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using TaskManager;

namespace TaskManager.Tests
{
    public class PerformanceTests
    {
        private IManager taskManager;
        
        [SetUp]
        public void Setup()
        {
            this.taskManager = new Manager();
        }

        [Test]
        public void AddTask_ShouldPassQuickly_WhenDoesNotExist_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                this.taskManager.AddTask(task);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var newTask = new Task
            {
                Id = GetNextId(),
                Priority = 1,
                Title = GetNextId(),
                Assignee = "John Smith",
            };

            this.taskManager.AddTask(newTask);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.taskManager.Size(), Is.EqualTo(count + 1));
            Assert.That(this.taskManager.Get(newTask.Id), Is.EqualTo(newTask));
        }

        [Test]
        public void RemoveTask_ShouldPassQuickly_WhenExists_With1000000Tasks()
        {
            // Arrange
            var targtId = string.Empty;
            for (int i = 0; i < 1_000_000; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                if (i == 500_000)
                {
                    targtId = task.Id;
                }

                this.taskManager.AddTask(task);
            }

            Assert.True(this.taskManager.Contains(targtId));

            // Act
            var sw = new Stopwatch();

            sw.Start();

            this.taskManager.RemoveTask(targtId);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.False(this.taskManager.Contains(targtId));
        }

        [Test]
        public void Contains_ShouldPassQuickly_WhenExists_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            var targetId = string.Empty;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                if (i == 500_000)
                {
                    targetId = task.Id;
                }

                this.taskManager.AddTask(task);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.taskManager.Contains(targetId);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.True(result);
        }


        [Test]
        public void Get_ShouldThrowQuickly_WhenDoesNotExist_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                this.taskManager.AddTask(task);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            Assert.Throws<ArgumentException>(
                () => this.taskManager.Get(GetNextId()));

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void Size_ShouldPassQuickly_WhenExists_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                this.taskManager.AddTask(task);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.taskManager.Size();

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(result, Is.EqualTo(count));
        }

        [Test]
        public void AddDependency_ShouldThrowQuickly_WhenTaskDoesNotExist_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            var targetId = string.Empty;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                if (i == 500_000)
                {
                    targetId = task.Id;
                }

                this.taskManager.AddTask(task);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            Assert.Throws<ArgumentException>(
                () => this.taskManager.AddDependency(GetNextId(), targetId));

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void AddDependency_ShouldPassQuickly_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            var taskTarget = null as Task;
            var dependencyTarget = null as Task;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                if (i == 500_000)
                {
                    taskTarget = task;
                }
                else if (i == 700_000)
                {
                    dependencyTarget = task;
                }

                this.taskManager.AddTask(task);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            this.taskManager.AddDependency(taskTarget.Id, dependencyTarget.Id);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.taskManager.GetDependencies(taskTarget.Id), Is.EquivalentTo(new List<Task> { dependencyTarget }));
            Assert.That(this.taskManager.GetDependents(dependencyTarget.Id), Is.EquivalentTo(new List<Task> { taskTarget}));
        }

        [Test]
        public void RemoveDependency_ShouldPassQuickly_WhenDependencyExists_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            var taskTarget = null as Task;
            var dependencyTarget = null as Task;
            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                if (i == 500_000)
                {
                    taskTarget = task;
                }
                else if (i == 650_000)
                {
                    dependencyTarget = task;
                }

                this.taskManager.AddTask(task);
            }

            this.taskManager.AddDependency(taskTarget.Id, dependencyTarget.Id);

            // Act
            var sw = new Stopwatch();

            sw.Start();

            this.taskManager.RemoveDependency(taskTarget.Id, dependencyTarget.Id);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.taskManager.GetDependencies(taskTarget.Id), Is.EquivalentTo(Enumerable.Empty<Task>()));
            Assert.That(this.taskManager.GetDependents(dependencyTarget.Id), Is.EquivalentTo(Enumerable.Empty<Task>()));
        }

        [Test]
        public void GetDependencies_ShouldPassQuickly_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            var taskTarget = null as Task;
            var existingDependencyTask = null as Task;
            var dependencies = new List<Task>();

            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };
                
                this.taskManager.AddTask(task);

                if (i == 499_999)
                {
                    existingDependencyTask = task;
                }
                if (i == 500_000)
                {
                    taskTarget = task;
                }
                else if (i == 500_001)
                {
                    this.taskManager.AddDependency(existingDependencyTask.Id, task.Id);
                    this.taskManager.AddDependency(taskTarget.Id, existingDependencyTask.Id);
                    dependencies.Add(existingDependencyTask);
                    dependencies.Add(task);
                }
                if (i > 500_001 && i <= 501_000)
                {
                    dependencies.Add(task);
                    this.taskManager.AddDependency(taskTarget.Id, task.Id);
                }
            }


            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.taskManager.GetDependencies(taskTarget.Id);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEquivalent(result, dependencies);
        }

        [Test]
        public void GetDependents_ShouldPassQuickly_With1000000Tasks()
        {
            // Arrange
            var count = 1_000_000;
            var taskTarget = null as Task;
            var existingDependencyTask = null as Task;
            
            var dependantTarget = null as Task;
            var dependants = new List<Task>();

            for (int i = 0; i < count; i++)
            {
                var task = new Task
                {
                    Id = GetNextId(),
                    Priority = 1,
                    Title = GetNextId(),
                    Assignee = "John Smith",
                };

                this.taskManager.AddTask(task);

                if (i == 499_999)
                {
                    existingDependencyTask = task;
                }
                if (i == 500_000)
                {
                    taskTarget = task;
                }
                else if (i == 500_001)
                {
                    this.taskManager.AddDependency(existingDependencyTask.Id, task.Id);
                    this.taskManager.AddDependency(taskTarget.Id, existingDependencyTask.Id);
                    
                    dependants.Add(existingDependencyTask);
                    dependants.Add(taskTarget);
                    dependantTarget = task;
                }
                if (i > 500_001 && i <= 501_000)
                {
                    this.taskManager.AddDependency(taskTarget.Id, task.Id);
                }
            }


            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.taskManager.GetDependents(dependantTarget.Id);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEquivalent(result, dependants);
        }

        private static string GetNextId()
            => Guid.NewGuid().ToString();
    }
}
