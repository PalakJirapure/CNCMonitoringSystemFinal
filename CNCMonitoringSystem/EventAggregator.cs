using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMonitoringSystem
{
    public class EventAggregator
    {
        private static EventAggregator _instance;
        private static readonly object _lockObject = new object();

        // Action delegates for events (no return value)
        public event Action<double> TemperatureExceeded;
        public event Action<double> DimensionVariationExceeded;
        public event Action<int> ContinuousOperationExceeded;
        public event Action<byte> SelfTestStatusChanged;

        private EventAggregator() { }

        public static EventAggregator Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new EventAggregator();
                    }
                }
                return _instance;
            }
        }

        public void PublishTemperatureExceeded(double temperature)
        {
            lock (_lockObject)
            {
                TemperatureExceeded?.Invoke(temperature);
            }
        }

        public void PublishDimensionVariationExceeded(double dimensionVariation)
        {
            lock (_lockObject)
            {
                DimensionVariationExceeded?.Invoke(dimensionVariation);
            }
        }

        public void PublishContinuousOperationExceeded(int operationDuration)
        {
            lock (_lockObject)
            {
                ContinuousOperationExceeded?.Invoke(operationDuration);
            }
        }

        public void PublishSelfTestStatusChanged(byte selfTestStatusCode)
        {
            lock (_lockObject)
            {
                SelfTestStatusChanged?.Invoke(selfTestStatusCode);
            }
        }
    }

}
