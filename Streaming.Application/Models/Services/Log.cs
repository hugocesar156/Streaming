namespace Streaming.Application.Models.Services
{
    public class Log
    {
        public Log()
        {
            Request = string.Empty;
            Error = string.Empty;
            Body = string.Empty;
        }

        public Log(string request, string error, string? description, int statusCode, string body, DateTime date)
        {
            Request = request;
            Error = error;
            Description = description;
            StatusCode = statusCode;
            Body = body;
            Date = date;
        }

        public string Request { get; private set; }
        public string Error { get; private set; }
        public string? Description { get; private set; }
        public int StatusCode { get; private set; }
        public string Body { get; private set; }
        public DateTime Date { get; private set; }
    }
}
