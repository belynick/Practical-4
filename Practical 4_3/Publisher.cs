namespace Practical_4_3
{
    internal class Publisher
    {
        private EventBus _eventBus;

        public Publisher(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void PublishEvent(string eventName, CustomEventArgs args)
        {
            _eventBus.PublishEvent(eventName, args);
        }
    }
}