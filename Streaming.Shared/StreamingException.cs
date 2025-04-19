using System.Net;

namespace Streaming.Shared
{
    public class StreamingException : Exception
    {
        public StreamingException(HttpStatusCode statusCode, string error, string? description)
        {
            StatusCode = statusCode;
            Error = error;
            Description = description;
        }

        public HttpStatusCode StatusCode { get; }
        public string Error { get; }
        public string? Description { get; }
    }
}
