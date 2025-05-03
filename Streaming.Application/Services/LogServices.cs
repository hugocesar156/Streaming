using Microsoft.Extensions.Logging;

namespace Streaming.Application.Services
{
    public class LogServices
    {
        public static void WriteFile<T>(ILogger<T> logger, string request, string error, string? description, int statusCode, string body = "")
        {
            logger.LogError("\nRequest: {0}\nError: {1}\nDescription: {2}\nStatusCode: {3}\nBody: {4}\n",
                      request, error, description, statusCode, body);
        }
    }
}
