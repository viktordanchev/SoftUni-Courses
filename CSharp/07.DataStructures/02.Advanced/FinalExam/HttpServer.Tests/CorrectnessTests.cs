using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HttpServer.Tests
{
    public class CorrectnessTests
    {
        private IHttpListener httpServer;

        [SetUp]
        public void Setup()
        {
            this.httpServer = new HttpListener();
        }

        [Test]
        public void AddRequest_ShouldAddPendingRequest()
        {
            // Arrange
            var request = new HttpRequest
            {
                Id = GetNextId(),
                Host = "judge.softuni.org",
                Method = "GET",
                Expires = null,
            };

            // Act
            this.httpServer.AddRequest(request);

            // Assert
            Assert.True(this.httpServer.Contains(request.Id));
            Assert.That(this.httpServer.Size(), Is.EqualTo(1));
            Assert.That(this.httpServer.GetRequest(request.Id), Is.EqualTo(request));
        }

        [Test]
        public void Contains_ShouldReturnFalse_WhenRequestsDoesNotExist()
        {
            // Arrange
            var request = new HttpRequest
            {
                Id = GetNextId(),
                Host = "judge.softuni.org",
                Method = "GET",
                Expires = null,
            };

            // Act
            this.httpServer.AddRequest(request);

            // Assert
            Assert.False(this.httpServer.Contains(GetNextId()));
        }

        [Test]
        public void GetRequest_ShouldThrowArgumentException_WhenRequestDoesNotExist()
        {
            // Arrange
            var request = new HttpRequest
            {
                Id = GetNextId(),
                Host = "judge.softuni.org",
                Method = "GET",
                Expires = null,
            };

            // Act
            this.httpServer.AddRequest(request);

            // Assert
            Assert.Throws<ArgumentException>(
                () => this.httpServer.GetRequest(GetNextId()));
        }

        [Test]
        public void CancelRequest_ShouldRemvoeTheRequestFromTheServer_WhenExists()
        {
            // Arrange
            var target = new HttpRequest
            {
                Id = GetNextId(),
                Host = "judge.softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddRequest(target);

            Assert.That(this.httpServer.Size(), Is.EqualTo(1));
            Assert.True(this.httpServer.Contains(target.Id));
            Assert.That(this.httpServer.GetRequest(target.Id), Is.EqualTo(target));

            // Act
            this.httpServer.CancelRequest(target.Id);

            // Assert
            Assert.Zero(this.httpServer.Size());
            Assert.False(this.httpServer.Contains(target.Id));
            Assert.Throws<ArgumentException>(() => this.httpServer.GetRequest(target.Id));
            Assert.That(this.httpServer.GetAllExecutedRequests(), Is.EqualTo(new List<HttpRequest>()));
        }

        [Test]
        public void GetByHost_ShouldReturnOnlyRequestsWithGivenHost()
        {
            // Arrange
            var targetHost = "judge.softuni.org";
            var request1 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request2 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request3 = new HttpRequest
            {
                Id = GetNextId(),
                Host = "softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddRequest(request1);
            this.httpServer.AddRequest(request2);
            this.httpServer.AddRequest(request3);

            // Act
            var result = this.httpServer.GetByHost(targetHost);

            // Assert
            Assert.That(result, Is.EqualTo(new List<HttpRequest> { request1, request2 }));
        }

        [Test]
        public void Execute_ShouldReturnTheFirstRequestInTheQueue()
        {
            // Arrange
            var targetHost = "judge.softuni.org";
            var request1 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request2 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request3 = new HttpRequest
            {
                Id = GetNextId(),
                Host = "softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddRequest(request1);
            this.httpServer.AddRequest(request2);
            this.httpServer.AddRequest(request3);

            // Act
            var result = this.httpServer.Execute();

            // Assert
            Assert.That(result, Is.EqualTo(request1));
            Assert.That(this.httpServer.Size(), Is.EqualTo(2));
            Assert.False(this.httpServer.Contains(request1.Id));
            Assert.True(this.httpServer.Contains(request2.Id));
            Assert.True(this.httpServer.Contains(request3.Id));
            CollectionAssert.AreEqual(this.httpServer.GetAllExecutedRequests(), new List<HttpRequest> { result });
        }

        [Test]
        public void AddPriorityRequest_ShoulBeNextExecutedRequest()
        {
            // Arrange
            var targetHost = "judge.softuni.org";
            var request1 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request2 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request3 = new HttpRequest
            {
                Id = GetNextId(),
                Host = "softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddRequest(request1);
            this.httpServer.AddRequest(request2);
            this.httpServer.AddPriorityRequest(request3);

            // Act
            var executedRequest = this.httpServer.Execute();

            // Assert
            Assert.That(executedRequest, Is.EqualTo(request3));
        }

        [Test]
        public void RescheduleRequest_ShoudlAddTheRequest_WhenExists()
        {
            // Arrange
            var targetHost = "judge.softuni.org";
            var request1 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request2 = new HttpRequest
            {
                Id = GetNextId(),
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request3 = new HttpRequest
            {
                Id = GetNextId(),
                Host = "softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddRequest(request1);
            this.httpServer.AddRequest(request2);
            this.httpServer.AddRequest(request3);

            var executedTask = this.httpServer.Execute();

            // Act
            var rescheduledRequest = this.httpServer.RescheduleRequest(executedTask.Id);

            // Assert
            Assert.That(rescheduledRequest, Is.EqualTo(executedTask));
            Assert.That(this.httpServer.GetRequest(rescheduledRequest.Id), Is.EqualTo(rescheduledRequest));
            Assert.That(this.httpServer.Size(), Is.EqualTo(3));
            Assert.True(this.httpServer.Contains(rescheduledRequest.Id));
        }

        private static string GetNextId() => Guid.NewGuid().ToString();
    }
}