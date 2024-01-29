namespace CNCMonitoringSystem
{
    class Program
    {
        static void Main()
        {
            // Initialize the EventAggregator
            var eventAggregator = EventAggregator.Instance;

            // Create and subscribe alerting services
            var machineAlertingService = new MachineAlertingService(eventAggregator);
            var environmentAlertingService = new EnvironmentAlertingService(eventAggregator);

            // Create and start the CNC machine monitor
            var cncMachineMonitor = new CncMachineMonitor(eventAggregator);
            cncMachineMonitor.StartMonitoring();

            // Create and start the StatusCodePublisher
            var statusCodePublisher = new StatusCodePublisher(eventAggregator);
            statusCodePublisher.PublishRandomStatusCode();

            // Create and subscribe the StatusCodeSubscriber
            var statusCodeSubscriber = new StatusCodeSubscriber(eventAggregator);

            // Keep the console application running
            Console.ReadLine();
        }
    }


}
