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
                Prefix = "DwollaUI"
            };

            Console.WriteLine("Connected to server");
            
            Metrics.Configure(metricsConfig);

            for (int i = 0; i < 100; i++)
            {
                Metrics.Counter("new-stat");
                Console.WriteLine("Sent stat");
            }

        }
    }
}
