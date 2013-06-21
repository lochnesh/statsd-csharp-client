using System;
using StatsdClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            var metricsConfig = new MetricsConfig
            {
                StatsdServerName = "localhost",
                Prefix = "myApp"
            };

            Console.WriteLine("Connected to server");
            
            Metrics.Configure(metricsConfig);

            Metrics.Counter("skyler");

            Console.WriteLine("Sent stat");
        }
    }
}
