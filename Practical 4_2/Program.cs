namespace Practical_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus();
            var subscriber1 = new Subscriber(eventBus, 1);
            var subscriber2 = new Subscriber(eventBus, 2);
            var subscriber3 = new Subscriber(eventBus, 3);

            var publisher = new Publisher(eventBus);

            publisher.PublishEvent("Event 3", 3, "Data for Event 3");
            publisher.PublishEvent("Event 1", 1, "Data for Event 1");
            publisher.PublishEvent("Event 2", 2, "Data for Event 2");
        }
    }
}
