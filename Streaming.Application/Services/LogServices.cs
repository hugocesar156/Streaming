using Microsoft.Extensions.Logging;
using Streaming.Application.Models.Services;

namespace Streaming.Application.Services
{
    public class LogServices
    {
        public static void Delete(DateTime cutOffDate)
        {
            var logFiles = Directory.GetFiles("Logs/");
            var logs = new List<Log>();

            if (logFiles.Any())
            {
                string[] filesToDelete = logFiles.Where(x => 
                    string.Compare(x, $"Logs/log{cutOffDate.Year}{cutOffDate.Month.ToString().PadLeft(2, '0')}{cutOffDate.Day.ToString().PadLeft(2, '0')}.txt") <= 0).ToArray();

                for (var i = 0; i < filesToDelete.Count(); i++)
                {
                    var path = filesToDelete[i];

                    if (File.Exists(path))
                        File.Delete(path);
                }
            }
        }

        public static List<Log> GetByInterval(DateTime dateStart, DateTime dateEnd)
        {
            var logFiles = Directory.GetFiles("Logs/");
            var logs = new List<Log>();

            if (logFiles.Any())
            {
                string firstLogPath = logFiles.First().Replace("Logs/", "").Replace("log", "").Replace(".txt", "");
                DateTime firstLogDate = new DateTime(int.Parse(firstLogPath.Substring(0, 4)), int.Parse(firstLogPath.Substring(4, 2)), int.Parse(firstLogPath.Substring(6, 2)));

                if (dateStart.Date > firstLogDate.Date)
                    dateStart = firstLogDate;

                if (dateEnd.Date > DateTime.Now.Date)
                    dateEnd = DateTime.Now;

                while (dateStart.Date <= dateEnd.Date)
                {
                    var path = $"Logs/log{dateStart.Year}{dateStart.Month.ToString().PadLeft(2, '0')}{dateStart.Day.ToString().PadLeft(2, '0')}.txt";

                    if (logFiles.Contains(path))
                    {
                        using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                        {
                            var lines = new List<string>();

                            using (var sr = new StreamReader(stream))
                            {
                                while (!sr.EndOfStream)
                                    lines.Add(sr.ReadLine() ?? string.Empty);
                            }

                            string[] requests = lines.Where(x => x.StartsWith("Request: ")).ToArray();
                            string[] errors = lines.Where(x => x.StartsWith("Error: ")).ToArray();
                            string[] descriptions = lines.Where(x => x.StartsWith("Description: ")).ToArray();
                            string[] statusCodes = lines.Where(x => x.StartsWith("StatusCode: ")).ToArray();
                            string[] bodies = lines.Where(x => x.StartsWith("Body: ")).ToArray();

                            for (var i = 0; i < requests.Count(); i++)
                            {
                                DateTime logDate = Convert.ToDateTime(lines[lines.IndexOf(requests[i]) - 1].Replace("-03:00 [ERR]", "").Trim());

                                logs.Add(new Log(
                                    requests[i].Replace("Request: ", ""),
                                    errors[i].Replace("Error: ", ""),
                                    descriptions[i].Replace("Description: ", ""),
                                    int.Parse(statusCodes[i].Replace("StatusCode: ", "")),
                                    bodies[i].Replace("Body: ", ""),
                                    logDate));
                            }
                        }
                    }

                    dateStart = dateStart.AddDays(1);
                }
            }

            return logs;
        }

        public static void WriteFile<T>(ILogger<T> logger, string request, string error, string? description, int statusCode, string body = "")
        {
            logger.LogError("\nRequest: {0}\nError: {1}\nDescription: {2}\nStatusCode: {3}\nBody: {4}\n",
                      request, error, description, statusCode, body);
        }
    }
}
