using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus(new RetryPolicy(5, new TimeSpan(0, 0, 1), new TimeSpan(0, 0, 5)));
            var subscriber1 = new Subscriber("event", eventBus);

            var publisher = new Publisher(eventBus);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    publisher.PublishEvent("event", new CustomEventArgs() { Name = "Publish" });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Event handling failed: {ex.Message}");
                }
            }

            Console.ReadLine();
        }
    }
}
