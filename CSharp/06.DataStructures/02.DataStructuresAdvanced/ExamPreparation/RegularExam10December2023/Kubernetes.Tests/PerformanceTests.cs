using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Kubernetes.Tests
{
    public class PerformanceTests
    {
        private IController controller;
        
        [SetUp]
        public void Setup()
        {
            this.controller = new Controller();
        }

        [Test]
        public void Deploy_SouldPassQuickly_With100000Pods()
        {
            // Arrange
            for (int i = 0; i < 100_000; i++)
            {
                var pod = new Pod
                {
                    Id = GetNextId(),
                    ServiceName = "amazon-shopping-engine" + i,
                    Port = 1000 + i,
                    Namespace = GetNextId(),
                };

                this.controller.Deploy(pod);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            this.controller.Deploy(new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine" + GetNextId(),
                Port = 10000,
                Namespace = GetNextId(),
            });

            sw.Stop();


            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.controller.Size(), Is.EqualTo(100_001));
        }

        [Test]
        public void GetPod_ShouldPassQuickly_With100000Pods()
        {
            // Arrange
            var target = null as Pod; ;
            for (int i = 0; i < 100_000; i++)
            {
                var pod = new Pod
                {
                    Id = GetNextId(),
                    ServiceName = "amazon-shopping-engine" + i,
                    Port = 1000 + i,
                    Namespace = GetNextId(),
                };

                if (i == 50_000)
                {
                    target = pod;
                }

                this.controller.Deploy(pod);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.controller.GetPod(target.Id);

            sw.Stop();


            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(result, Is.EqualTo(target));
        }

        [Test]
        public void Contains_ShouldPassQuickly_With100000Pods_WhenExists()
        {
            // Arrange
            var target = string.Empty;
            for (int i = 0; i < 100_000; i++)
            {
                var pod = new Pod
                {
                    Id = GetNextId(),
                    ServiceName = "amazon-shopping-engine" + i,
                    Port = 1000 + i,
                    Namespace = GetNextId(),
                };

                if (i == 50_000)
                {
                    target = pod.Id;
                }

                this.controller.Deploy(pod);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.controller.Contains(target);

            sw.Stop();


            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.True(result);
        }

        [Test]
        public void Uninstall_ShouldPassQuickly_With100000Pods_WhenExists()
        {
            // Arrange
            var target = string.Empty;
            for (int i = 0; i < 100_000; i++)
            {
                var pod = new Pod
                {
                    Id = GetNextId(),
                    ServiceName = "amazon-shopping-engine" + i,
                    Port = 1000 + i,
                    Namespace = GetNextId(),
                };

                if (i == 50_000)
                {
                    target = pod.Id;
                }

                this.controller.Deploy(pod);
            }

            Assert.True(this.controller.Contains(target));

            // Act
            var sw = new Stopwatch();

            sw.Start();

            this.controller.Uninstall(target);

            sw.Stop();


            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.False(this.controller.Contains(target));
        }

        [Test]
        public void Upgrade_SouldPassQuickly_With100000Pods_WhenExists()
        {
            // Arrange
            var podsCounter = 100_000;
            var target = null as Pod;
            for (int i = 0; i < podsCounter; i++)
            {
                var pod = new Pod
                {
                    Id = GetNextId(),
                    ServiceName = "amazon-shopping-engine" + i,
                    Port = 1000 + i,
                    Namespace = GetNextId(),
                };

                if (i == podsCounter / 2)
                {
                    target = pod;
                }

                this.controller.Deploy(pod);
            }

            Assert.True(this.controller.Contains(target.Id));

            var upgradePod = new Pod
            {
                Id = target.Id,
                Namespace = GetNextId(),
                Port = 9999,
                ServiceName = "fincore-engine",
            };

            // Act
            var sw = new Stopwatch();

            sw.Start();

            this.controller.Upgrade(upgradePod);

            sw.Stop();


            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.controller.Size(), Is.EqualTo(podsCounter));
            Assert.That(this.controller.GetPod(target.Id), Is.EqualTo(upgradePod));
        }

        [Test]
        public void GetPodsInNamespace_ShouldPassQuickly_With100Namespaces()
        {
            // Arrange
            var namespaces = Enumerable.Range(1, 100)
                .Select(x => GetNextId())
                .ToArray();

            var podsPerNamespace = 1000;

            var targetNamespace = namespaces[namespaces.Length / 2];
            var expectedPods = new List<Pod>();

            foreach (var @namespace in namespaces)
            {
                for (int i = 0; i < podsPerNamespace; i++)
                {
                    var pod = new Pod
                    {
                        ServiceName = GetNextId(),
                        Id = GetNextId(),
                        Namespace = @namespace,
                        Port = i,
                    };

                    this.controller.Deploy(pod);

                    if (@namespace == targetNamespace)
                    {
                        expectedPods.Add(pod);
                    }
                }
            }


            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.controller.GetPodsInNamespace(targetNamespace);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEqual(result, expectedPods);
        }

        [Test]
        public void GetPodsBetweenPort_ShouldPassQuickly_With1000000Pods()
        {
            // Arrange
            var lower = 400_000;
            var upper = 600_000;
            var expectedPods = new List<Pod>();

            for (int i = 0; i < 1_000_000; i++)
            {
                var pod = new Pod
                {
                    ServiceName = GetNextId(),
                    Id = GetNextId(),
                    Namespace = GetNextId(),
                    Port = i,
                };

                if (i >= lower && i <= upper)
                {
                    expectedPods.Add(pod);
                }

                this.controller.Deploy(pod);
            }

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.controller.GetPodsBetweenPort(lower, upper);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEqual(result, expectedPods);
        }

        [Test]
        public void GetPodsOrderedByPortThenByName_ShouldPassQuickly_With1000000Pods()
        {
            // Arrange
            var pods = new List<Pod>();

            for (int i = 0; i < 1_000_000; i++)
            {
                var firstLetter = string.Empty;
                if (i % 2 == 0)
                {
                    firstLetter = "C";
                }
                else if (i % 3 == 0)
                {
                    firstLetter = "B";
                }
                else
                {
                    firstLetter = "A";
                }

                var port = i % 100 == 0 ? 1_000_000 : i;

                var pod = new Pod
                {
                    ServiceName = firstLetter + GetNextId(),
                    Id = GetNextId(),
                    Namespace = GetNextId(),
                    Port = port,
                };

                this.controller.Deploy(pod);
                pods.Add(pod);
            }

            var expectedResult = pods
                .OrderByDescending(p => p.Port)
                .ThenBy(p => p.Namespace);

            // Act
            var sw = new Stopwatch();

            sw.Start();

            var result = this.controller.GetPodsOrderedByPortThenByName();

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            CollectionAssert.AreEqual(expectedResult, result);
        }

        private static string GetNextId()
            => Guid.NewGuid().ToString();
    }
}
