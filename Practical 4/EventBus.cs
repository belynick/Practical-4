using System;
using System.Collections.Generic;

namespace Practical_4
{
    internal class EventBus
    {
        private Dictionary<string, Delegate> _eventHandlers;
        private EventThrottler _throttler;

        public EventBus(TimeSpan throttleInterval)
        {
            _eventHandlers = new Dictionary<string, Delegate>();
            _throttler = new EventThrottler(throttleInterval);
        }

        public void Register(string eventName, Delegate handler)
        {
            if (_eventHandlers.ContainsKey(eventName))
            {
                _eventHandlers[eventName] = Delegate.Combine(_eventHandlers[eventName], handler);
            }
            else
            {
                _eventHandlers[eventName] = handler;
            }
        }

        public void Unregister(string eventName, Delegate handler)
        {
            if (_eventHandlers.ContainsKey(eventName))
            {
                _eventHandlers[eventName] = Delegate.Remove(_eventHandlers[eventName], handler);
            }
        }

        public void SendEvent(string eventName, object eventData)
        {
            if (_eventHandlers.ContainsKey(eventName))
            {
                if (_throttler.CanSendEvent())
                {
                    EventData data = new EventData { Name = eventName, TimeStamp = DateTime.Now, Data = eventData };
                    Delegate handler = _eventHandlers[eventName];
                    handler.DynamicInvoke(data);
                }
            }
        }
    }
}
