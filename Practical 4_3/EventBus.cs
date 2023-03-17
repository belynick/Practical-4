using System;
using System.Collections.Generic;
using System.Threading;

namespace Practical_4_3
{
    internal class EventBus
    {
        private Dictionary<string, List<CustomEventHandler>> _subscribers;
        public delegate void CustomEventHandler(object sender, CustomEventArgs e);
        private readonly object subscribersLock = new object();
        private readonly Random random = new Random();
        private readonly RetryPolicy retryPolicy;

        public EventBus(RetryPolicy retryPolicy)
        {
            _subscribers = new Dictionary<string, List<CustomEventHandler>>();
            this.retryPolicy = retryPolicy;
        }

        public void Subscribe(string name, CustomEventHandler handler)
        {
            if (!_subscribers.ContainsKey(name))
            {
                _subscribers.Add(name, new List<CustomEventHandler>());
            }
            _subscribers[name].Add(handler);
        }

        public void Unsubscribe(string name, CustomEventHandler handler)
        {
            if (_subscribers.ContainsKey(name))
            {
                _subscribers[name].Remove(handler);
            }
        }

        public void PublishEvent(string eventName, CustomEventArgs args)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    if (random.Next(0, 2) == 1)
                        throw new Exception();

                    foreach (var subscriber in _subscribers[eventName])
                    {
                        subscriber(this, args);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    if (retryCount >= retryPolicy.MaxRetries)
                        throw;

                    retryCount++;

                    TimeSpan delay = retryPolicy.GetDelay(retryCount);
                    int jitter = random.Next((int)delay.TotalMilliseconds / 4);
                    delay += TimeSpan.FromMilliseconds(jitter);

                    Thread.Sleep(delay);
                }
            }
        }
    }
}