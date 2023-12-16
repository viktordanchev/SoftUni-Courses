using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class Manager : IManager
    {
        public void AddDependency(string taskId, string dependentTaskId)
        {
            throw new NotImplementedException();
        }

        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string taskId)
        {
            throw new NotImplementedException();
        }

        public Task Get(string taskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(string taskId)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}