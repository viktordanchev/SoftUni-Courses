using System.Collections.Generic;

namespace HttpServer
{
    public class HttpListener : IHttpListener
    {
        public void AddPriorityRequest(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }

        public void AddRequest(HttpRequest request)
        {
            throw new System.NotImplementedException();
        }

        public void CancelRequest(string requestId)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(string requestId)
        {
            throw new System.NotImplementedException();
        }

        public HttpRequest Execute()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HttpRequest> GetAllExecutedRequests()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HttpRequest> GetByHost(string host)
        {
            throw new System.NotImplementedException();
        }

        public HttpRequest GetRequest(string requestId)
        {
            throw new System.NotImplementedException();
        }

        public HttpRequest RescheduleRequest(string requestId)
        {
            throw new System.NotImplementedException();
        }

        public int Size()
        {
            throw new System.NotImplementedException();
        }
    }
}
