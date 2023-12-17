namespace HttpServer
{
    public class HttpRequest
    {
        public string Id { get; set; }

        public string Method { get; set; }

        public long? Expires { get; set; }

        public string Host { get; set; }
    }
}
