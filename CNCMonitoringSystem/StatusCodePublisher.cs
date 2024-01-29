using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMonitoringSystem
{
    public class StatusCodePublisher
    {
        private readonly EventAggregator _eventAggregator;
        private readonly Random _random;

        public StatusCodePublisher(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _random = new Random();
        }

        public void PublishRandomStatusCode()
        {
            byte statusCode = GetRandomStatusCode();
            _eventAggregator.PublishSelfTestStatusChanged(statusCode);
        }

        private byte GetRandomStatusCode()
        {
            // Generate a random index to select a status code
            int index = _random.Next(0, 4);

            // Corresponding status codes
            byte[] statusCodes = { 0xFF, 0x00, 0x01, 0x02 };

            return statusCodes[index];
        }
    }
}
