using System;
using System.Threading;

namespace Practical_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventBus eventBus = new EventBus(TimeSpan.FromSeconds(1));

            eventBus.Register("Event1", new Action<EventData>(data =>
            {
                Console.WriteLine($"Event {data.Name} handled at {data.TimeStamp}");
            }));

            eventBus.Register("Event2", new Action<EventData>(data =>
            {
                Console.WriteLine($"Event {data.Name} handled at {data.TimeStamp}");
            }));


            int count = 0;
            while (count < 5)
            {
                eventBus.SendEvent("Event1", $"Event data {count}");
                eventBus.SendEvent("Event2", $"Event data {count}");
                count++;
                Thread.Sleep(500);
            }
        }
    }
}