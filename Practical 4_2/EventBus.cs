using System;
using System.Collections.Generic;

namespace Practical_4_2
{

    internal class EventBus
    {
        private Dictionary<int, List<CustomEventHandler>> _subscribers;
        public delegate void CustomEventHandler(object sender, CustomEventArgs e);

        public EventBus()
        {
            _subscribers = new Dictionary<int, List<CustomEventHandler>>();
        }

        public void Subscribe(int priority, CustomEventHandler handler)
        {
            if (!_subscribers.ContainsKey(priority))
            {
                _subscribers.Add(priority, new List<CustomEventHandler>());
            }
            _subscribers[priority].Add(handler);
        }

        public void Unsubscribe(int priority, CustomEventHandler handler)
        {
            if (_subscribers.ContainsKey(priority))
            {
                _subscribers[priority].Remove(handler);
            }
        }

        public void Publish(string name, int priority, object data)
        {
            var e = new CustomEventArgs { Name = name, Priority = priority, Data = data };

            foreach (var handler in _subscribers[priority])
            {
                handler(this, e);
            }
        }
    }
}