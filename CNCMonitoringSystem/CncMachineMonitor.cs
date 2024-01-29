using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace CNCMonitoringSystem
{
    public enum MonitoringStatus
    {
        Off,
        On
    }

    public class CncMachineMonitor : ICncMachineMonitor
    {
        private readonly EventAggregator _eventAggregator;
        private readonly Timer _monitoringTimer;
        private MonitoringStatus _monitoringStatus;

        public CncMachineMonitor(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _monitoringTimer = new Timer(Monitor, null, Timeout.Infinite, Timeout.Infinite);
            _monitoringStatus = MonitoringStatus.Off;
        }

        private void Monitor(object state)
        {
            // Simulate monitoring and raise events when conditions are met
            Random random = new Random();

            double temperature = random.Next(30, 40);
            double dimensionVariation = random.NextDouble() * 0.1;
            int operationDuration = random.Next(0, 480);
            byte selfTestStatusCode = (byte)random.Next(0, 3);

            // Publish events using the EventAggregator
            _eventAggregator.PublishTemperatureExceeded(temperature);
            _eventAggregator.PublishDimensionVariationExceeded(dimensionVariation);
            _eventAggregator.PublishContinuousOperationExceeded(operationDuration);
            _eventAggregator.PublishSelfTestStatusChanged(selfTestStatusCode);
        }

        public void StartMonitoring()
        {
            if (_monitoringStatus == MonitoringStatus.Off)
            {
                _monitoringTimer.Change(0, 15000);
                _monitoringStatus = MonitoringStatus.On;
                Console.WriteLine("CNC Machine Monitoring started.");
            }
            else
            {
                Console.WriteLine("CNC Machine Monitoring is already started.");
            }
        }

        public void StopMonitoring()
        {
            if (_monitoringStatus == MonitoringStatus.On)
            {
                _monitoringTimer.Change(Timeout.Infinite, Timeout.Infinite);
                _monitoringStatus = MonitoringStatus.Off;
                Console.WriteLine("CNC Machine Monitoring stopped.");
            }
            else
            {
                Console.WriteLine("CNC Machine Monitoring is not currently running.");
            }
        }

        public MonitoringStatus GetMonitoringStatus()
        {
            return _monitoringStatus;
        }
    }

}
