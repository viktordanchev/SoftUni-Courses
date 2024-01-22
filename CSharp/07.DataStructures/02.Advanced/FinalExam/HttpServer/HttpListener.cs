using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpServer
{
    public class HttpListener : IHttpListener
    {
        private Dictionary<string, HttpRequest> Requests;
        private Dictionary<string, HttpRequest> ExecutedRequests;

        public HttpListener()
        {
            Requests = new Dictionary<string, HttpRequest>();
            ExecutedRequests = new Dictionary<string, HttpRequest>();
        }

        public void AddPriorityRequest(HttpRequest request)
        {
            if (Requests.ContainsKey(request.Id))
            {
                throw new ArgumentException();
            }

            Requests.Add(request.Id, request);
        }

        public void AddRequest(HttpRequest request)
        {
            Requests.Add(request.Id, request);
        }

        public void CancelRequest(string requestId)
        {
            if(!Requests.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            Requests.Remove(requestId);
        }

        public bool Contains(string requestId)
        {
            return Requests.ContainsKey(requestId);
        }

        public HttpRequest Execute()
        {
            if (Requests.Count == 0)
            {
                throw new ArgumentException();
            }

            var request = Requests.First().Value;
            Requests.Remove(request.Id);
            ExecutedRequests.Add(request.Id, request);

            return request;
        }

        public IEnumerable<HttpRequest> GetAllExecutedRequests()
        {
            return ExecutedRequests.Values;
        }

        public IEnumerable<HttpRequest> GetByHost(string host)
        {
            return Requests.Values.Where(r => r.Host == host);
        }

        public HttpRequest GetRequest(string requestId)
        {
            if (!Requests.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            return Requests.First(r => r.Key == requestId).Value;
        }

        public HttpRequest RescheduleRequest(string requestId)
        {
            var request = ExecutedRequests.First(r => r.Key == requestId).Value;

            if(request == null)
            {
                throw new ArgumentException();
            }

            Requests.Add(request.Id, request);

            return request;
        }

        public int Size()
        {
            return Requests.Count;
        }
    }
}
