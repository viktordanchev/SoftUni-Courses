using NUnit.Framework;
using System;
using System.Diagnostics;
using HttpServer;

namespace HttpServer.Tests
{
    public class PerformanceTests
    {
        private IHttpListener httpServer;

        [SetUp]
        public void Setup()
        {
            this.httpServer = new HttpListener();
        }

        [Test]
        public void AddRequest_ShouldPassQuickly_With1000000Requests()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };


                this.httpServer.AddRequest(request);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var newRequest = new HttpRequest
            {
                Id = GetNextId(),
                Host = "judge.softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddRequest(newRequest);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.httpServer.Size(), Is.EqualTo(count + 1));
            Assert.True(this.httpServer.Contains(newRequest.Id));
        }

        [Test]
        public void AddPriorityRequest_ShouldPassQuickly_With1000000Requests()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };


                this.httpServer.AddRequest(request);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var newRequest = new HttpRequest
            {
                Id = GetNextId(),
                Host = "judge.softuni.org",
                Method = "GET",
                Expires = null,
            };

            this.httpServer.AddPriorityRequest(newRequest);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.httpServer.Size(), Is.EqualTo(count + 1));
            Assert.True(this.httpServer.Contains(newRequest.Id));
        }

        [Test]
        public void CancelRequest_ShouldPassQuickly_With1000000Requests()
        {
            // Arrange
            var count = 1_000_000;
            var targetRequestId = string.Empty;
            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };

                if (i == 500_000)
                {
                    targetRequestId = request.Id;
                }


                this.httpServer.AddRequest(request);
            }

            // Act
            var sw = Stopwatch.StartNew();

            this.httpServer.CancelRequest(targetRequestId);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(this.httpServer.Size(), Is.EqualTo(count - 1));
            Assert.False(this.httpServer.Contains(targetRequestId));
        }

        [Test]
        public void Contains_ShouldPassQuickly_With1000000Requests()
        {
            // Arrange
            var count = 1_000_000;
            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };

                this.httpServer.AddRequest(request);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.httpServer.Contains(GetNextId());

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.False(result);
        }

        [Test]
        public void GetRequest_ShouldPassQuickly_With1000000Requests_WhenExists()
        {
            // Arrange
            var count = 1_000_000;
            var target = null as HttpRequest;
            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };

                if (i == 500_000)
                {
                    target = request;
                }

                this.httpServer.AddRequest(request);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var result = this.httpServer.GetRequest(target.Id);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(result, Is.EqualTo(target));
        }

        [Test]
        public void RescheduleRequest_ShouldPassQuickly_With1000000Requests_WhenExist()
        {
            // Arrange
            var count = 1_000_000;
            var target = null as HttpRequest;
            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };

                this.httpServer.AddRequest(request);
                
                var executedTask = this.httpServer.Execute();

                if (i == 600_00)
                {
                    target = executedTask;
                }
            }

            for (int i = 0; i < count; i++)
            {
                var request = new HttpRequest
                {
                    Id = GetNextId(),
                    Host = "judge.softuni.org",
                    Method = "GET",
                    Expires = null,
                };

                this.httpServer.AddRequest(request);
            }

            // Act
            var sw = Stopwatch.StartNew();

            var rescheduledRequest = this.httpServer.RescheduleRequest(target.Id);

            sw.Stop();

            // Assert
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
            Assert.That(rescheduledRequest, Is.EqualTo(target));
            Assert.That(this.httpServer.Size(), Is.EqualTo(count + 1));
        }

        private static string GetNextId() => Guid.NewGuid().ToString();
    }
}