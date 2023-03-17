using System;

namespace Practical_4_3
{
    internal class Subscriber
    {
        public Subscriber(string name, EventBus eventBus)
        {
            eventBus.Subscribe(name, CustomEventHandler);
        }

        private void CustomEventHandler(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"Handling event {e.Name}");
        }
    }
}
