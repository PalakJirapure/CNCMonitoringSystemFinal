using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMonitoringSystem
{
    public class StatusCodeSubscriber
    {
        private readonly EventAggregator _eventAggregator;

        public StatusCodeSubscriber(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            // Subscribe to self-test status code changes
            _eventAggregator.SelfTestStatusChanged += HandleSelfTestStatusChanged;
        }

        private void HandleSelfTestStatusChanged(byte selfTestStatusCode)
        {
            Console.WriteLine($"Received Status Code: 0x{selfTestStatusCode:X} - Meaning: {GetStatusCodeMeaning(selfTestStatusCode)}");
        }

        private string GetStatusCodeMeaning(byte statusCode)
        {
            // Mapping of status codes to meanings
            var statusMeanings = new Dictionary<byte, string>
        {
            { 0xFF, "All ok" },
            { 0x00, "No data (examples: no power, no connection to the data-collector)" },
            { 0x01, "Controller board in the machine is not ok" },
            { 0x02, "Configuration data in the machine is corrupted" }
        };

            // Retrieve the meaning based on the status code
            return statusMeanings.ContainsKey(statusCode) ? statusMeanings[statusCode] : "Unknown Status Code";
        }
    }

}
