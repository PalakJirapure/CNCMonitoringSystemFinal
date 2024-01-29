using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMonitoringSystem
{
    public class MachineAlertingService : IAlertingService
    {
        private readonly EventAggregator _eventAggregator;

        public MachineAlertingService(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            // Subscribe to events
            _eventAggregator.TemperatureExceeded += HandleTemperatureExceeded;
            _eventAggregator.DimensionVariationExceeded += HandleDimensionVariationExceeded;
            _eventAggregator.ContinuousOperationExceeded += HandleContinuousOperationExceeded;
            _eventAggregator.SelfTestStatusChanged += HandleSelfTestStatusChanged;
        }

        private void HandleTemperatureExceeded(double temperature)
        {
            Console.WriteLine($"Machine Alert: High temperature detected in the machine. Temperature: {temperature}");
        }

        private void HandleDimensionVariationExceeded(double dimensionVariation)
        {
            Console.WriteLine($"Machine Alert: Part dimension variation exceeded. Variation: {dimensionVariation}");
        }

        private void HandleContinuousOperationExceeded(int operationDuration)
        {
            Console.WriteLine($"Machine Alert: Continuous operation duration exceeded. Duration: {operationDuration} minutes");
        }

        private void HandleSelfTestStatusChanged(byte selfTestStatusCode)
        {
            Console.WriteLine($"Machine Alert: Self-test status code changed. Code: 0x{selfTestStatusCode:X}");
        }

        public void Alert(string message)
        {
            Console.WriteLine($"Machine Alert: {message}");
        }
    }

}
