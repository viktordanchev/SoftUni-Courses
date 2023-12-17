using System.Collections.Generic;

namespace HttpServer
{
    public interface IHttpListener
    {
        void AddRequest(HttpRequest request);
     
        void AddPriorityRequest(HttpRequest request);
        
        bool Contains(string requestId);
        
        int Size();
        
        HttpRequest GetRequest(string requestId);
        
        void CancelRequest(string requestId);
        
        HttpRequest Execute();
        
        HttpRequest RescheduleRequest(string requestId);
        
        IEnumerable<HttpRequest> GetByHost(string host);
        
        IEnumerable<HttpRequest> GetAllExecutedRequests();
    }

}
