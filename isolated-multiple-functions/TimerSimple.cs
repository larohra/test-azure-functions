using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace multiple_functions
{
    public class TimerSimple
    {
        private readonly ILogger _logger;

        public TimerSimple(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TimerSimple>();
        }

        [Function("TimerSimple")]
        public void Run([TimerTrigger("*/45 * * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
