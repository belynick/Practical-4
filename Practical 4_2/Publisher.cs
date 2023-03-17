namespace Practical_4_2
{
    internal class Publisher
    {
        private EventBus _eventBus;

        public Publisher(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void PublishEvent(string name, int priority, object data)
        {
            _eventBus.Publish(name, priority, data);
        }
    }
}
