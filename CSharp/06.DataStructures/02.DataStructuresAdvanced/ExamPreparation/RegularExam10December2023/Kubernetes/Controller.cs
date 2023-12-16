using System;
using System.Collections.Generic;

namespace Kubernetes
{
    public class Controller : IController
    {
        public bool Contains(string podId)
        {
            throw new NotImplementedException();
        }

        public void Deploy(Pod pod)
        {
            throw new NotImplementedException();
        }

        public Pod GetPod(string podId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public void Uninstall(string podId)
        {
            throw new NotImplementedException();
        }

        public void Upgrade(Pod pod)
        {
            throw new NotImplementedException();
        }
    }
}