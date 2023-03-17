using System;

namespace Practical_4_2
{
    internal class Subscriber
    {
        public Subscriber(EventBus eventBus, int priority)
        {
            eventBus.Subscribe(priority, CustomEventHandler);
        }

        private void CustomEventHandler(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"Handling event '{e.Name}' with priority {e.Priority}: {e.Data}");
        }
    }
}
