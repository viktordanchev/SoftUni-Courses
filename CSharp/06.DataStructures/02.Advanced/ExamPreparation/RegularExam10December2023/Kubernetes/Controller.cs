using System;
using System.Collections.Generic;
using System.Linq;

namespace Kubernetes
{
    public class Controller : IController
    {
        private Dictionary<string, Pod> Pods = new Dictionary<string, Pod>();

        public bool Contains(string podId)
        {
            return Pods.ContainsKey(podId);
        }

        public void Deploy(Pod pod)
        {
            if (!Pods.ContainsKey(pod.Id))
            {
                Pods.Add(pod.Id, pod);
            }
        }

        public Pod GetPod(string podId)
        {
            if (!Pods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            return Pods[podId];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return Pods.Values.Where(p => p.Port >= lowerBound && p.Port <= upperBound);
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            return Pods.Values.Where(p => p.Namespace == @namespace);
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            var pods = Pods.OrderByDescending(p => p).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                
            return pods.Values.OrderBy(p => p.ServiceName);
        }

        public int Size()
        {
            return Pods.Count;
        }

        public void Uninstall(string podId)
        {
            if (!Pods.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            Pods.Remove(podId);
        }

        public void Upgrade(Pod pod)
        {
            if (Pods.ContainsKey(pod.Id))
            {
                Pods[pod.Id] = pod;
            }
        }
    }
}