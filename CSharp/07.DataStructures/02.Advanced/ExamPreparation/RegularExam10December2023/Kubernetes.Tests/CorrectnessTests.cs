using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Kubernetes.Tests
{
    public class CorrectnessTests
    {
        private IController controller;
        
        [SetUp]
        public void Setup()
        {
            this.controller = new Controller();
        }

        [Test]
        public void Deploy_ShouldAddThePod()
        {
            // Arrange
            var pod = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine",
                Port = 1000,
                Namespace = "amazon",
            };
            
            // Act
            this.controller.Deploy(pod);
            
            // Assert
            Assert.True(this.controller.Contains(pod.Id));
            Assert.That(this.controller.Size(), Is.EqualTo(1));
            Assert.That(this.controller.GetPod(pod.Id), Is.EqualTo(pod));
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenPodIdIsNotFound()
        {
            // Arrange
            var pod = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine",
                Port = 1000,
                Namespace = "amazon",
            };
            
            // Act
            this.controller.Deploy(pod);
            
            // Assert
            Assert.False(this.controller.Contains(GetNextId()));
        }

        [Test]
        public void Size_ShouldReturnDeployedPodsCount()
        {
            // Arrange
            var pod = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine",
                Port = 1000,
                Namespace = "amazon",
            };
            
            Assert.Zero(this.controller.Size());
            
            // Act
            this.controller.Deploy(pod);
            
            // Assert
            Assert.That(this.controller.Size(), Is.EqualTo(1));
        }

        [Test]
        public void Uninstall_ShouldRemoveThePod_WhenExists()
        {
            // Arrange
            var pod1 = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine",
                Port = 1000,
                Namespace = "amazon",
            };
            
            var pod2 = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-payment-engine",
                Port = 1010,
                Namespace = "amazon",
            };
            
            // Act
            this.controller.Deploy(pod1);
            this.controller.Deploy(pod2);
            this.controller.Uninstall(pod1.Id);

            // Assert
            Assert.False(this.controller.Contains(pod1.Id));
            Assert.That(this.controller.Size(), Is.EqualTo(1));
            Assert.Throws<ArgumentException>(
                () => this.controller.GetPod(pod1.Id));
        }

        [Test]
        public void Upgrade_ShouldUpdatePodProperties_WhenPodExists()
        {
            // Arrange
            var pod = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine",
                Port = 1000,
                Namespace = "amazon",
            };

            var upgradePod = new Pod
            {
                Id = pod.Id,
                ServiceName = "amazon-cart-engine",
                Port = 1100,
                Namespace = "amazon-cart"
            };
            
            // Act
            this.controller.Deploy(pod);
            this.controller.Upgrade(upgradePod);

            // Assert
            var existingPod = this.controller.GetPod(pod.Id);

            Assert.True(this.controller.Contains(pod.Id));
            Assert.That(this.controller.Size(), Is.EqualTo(1));
            Assert.That(existingPod.Id, Is.EqualTo(pod.Id));
            Assert.That(existingPod.Namespace, Is.EqualTo(upgradePod.Namespace));
            Assert.That(existingPod.ServiceName, Is.EqualTo(upgradePod.ServiceName));
            Assert.That(existingPod.Port, Is.EqualTo(upgradePod.Port));
        }

        [Test]
        public void GetPodsInNamespace_ShouldReturnOnlyPodsInTheSpecifiedNamespace()
        {
            // Arrange
            var pod1 = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-shopping-engine",
                Port = 1000,
                Namespace = "amazon",
            };

            var pod2 = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-cart-engine",
                Port = 1100,
                Namespace = "amazon-cart"
            };
            
            var pod3 = new Pod
            {
                Id = GetNextId(),
                ServiceName = "amazon-notifications",
                Port = 1100,
                Namespace = "amazon",
            };

            var expectedResult = new[]
            {
                pod1,
                pod3
            };
            
            this.controller.Deploy(pod1);
            this.controller.Deploy(pod2);
            this.controller.Deploy(pod3);
            
            // Act
            var result = this.controller.GetPodsInNamespace(pod1.Namespace);

            // Assert
            Assert.That(this.controller.Size(), Is.EqualTo(3));
            Assert.That(
                result, 
                Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void GetPodsBetweenPort_ShouldReturnOnlyPodsBetweenSpecifiedBounds()
        {
            // Arrange
            var expectedResult = new List<Pod>();
            var lowerBound = 1030;
            var upperBound = 1050;
            for (int i = 0; i < 100; i++)
            {
                var port = 1000 + i;
                var pod = new Pod
                {
                    Id = GetNextId(),
                    Port = 1000 + i,
                    Namespace = "amazon",
                    ServiceName = "microservice " + i,
                };

                this.controller.Deploy(pod);
                if (port >= lowerBound && port <= upperBound)
                {
                    expectedResult.Add(pod);
                }
            }
            
            // Act
            var result = this.controller.GetPodsBetweenPort(lowerBound, upperBound);

            // Assert
            Assert.That(
                result,
                Is.EquivalentTo(expectedResult));
        }

        private static string GetNextId()
            => Guid.NewGuid().ToString();
    }
}
