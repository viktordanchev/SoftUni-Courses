using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace HttpServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new HttpListener();

            var targetHost = "judge.softuni.org";
            var request1 = new HttpRequest
            {
                Id = "1",
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request2 = new HttpRequest
            {
                Id = "2",
                Host = targetHost,
                Method = "GET",
                Expires = null,
            };

            var request3 = new HttpRequest
            {
                Id = "3",
                Host = "softuni.org",
                Method = "GET",
                Expires = null,
            };

            list.AddRequest(request1);
            list.AddRequest(request2);
            list.AddRequest(request3);

            Console.WriteLine(list.Execute().Host);
        }
    }
}
