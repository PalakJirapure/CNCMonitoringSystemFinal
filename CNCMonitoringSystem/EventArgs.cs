using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMonitoringSystem
{
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
    }

    public class DimensionEventArgs : EventArgs
    {
        public double Variation { get; set; }
    }

    public class OperationDurationEventArgs : EventArgs
    {
        public int Duration { get; set; }
    }

    public class SelfTestStatusEventArgs : EventArgs
    {
        public byte StatusCode { get; set; }
    }
}
