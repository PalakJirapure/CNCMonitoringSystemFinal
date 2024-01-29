using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMonitoringSystem
{
    public class EnvironmentAlertingService : IAlertingService
    {
        private readonly EventAggregator _eventAggregator;

        public EnvironmentAlertingService(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            // Subscribe to events
            _eventAggregator.SelfTestStatusChanged += HandleSelfTestStatusChanged;
        }

        private void HandleSelfTestStatusChanged(byte selfTestStatusCode)
        {
            Console.WriteLine($"Environment Alert: CNC machine self-test status code changed. Code: 0x{selfTestStatusCode:X}");
        }

        public void Alert(string message)
        {
            Console.WriteLine($"Environment Alert: {message}");
        }
    }

}
