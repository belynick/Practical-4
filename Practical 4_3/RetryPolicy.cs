using System;

namespace Practical_4_3
{
    internal class RetryPolicy
    {
        private int maxRetries;
        private TimeSpan initialDelay;
        private TimeSpan maxDelay;

        public RetryPolicy(int maxRetries, TimeSpan initialDelay, TimeSpan maxDelay)
        {
            this.maxRetries = maxRetries;
            this.initialDelay = initialDelay;
            this.maxDelay = maxDelay;
        }

        public int MaxRetries
        {
            get { return maxRetries; }
        }

        public TimeSpan GetDelay(int retryCount)
        {
            if (retryCount < 0)
                throw new ArgumentOutOfRangeException("retryCount");

            if (retryCount == 0)
                return initialDelay;

            long delayTicks = (long)(initialDelay.Ticks * Math.Pow(2, retryCount - 1));
            delayTicks = Math.Min(delayTicks, maxDelay.Ticks);
            return TimeSpan.FromTicks(delayTicks);
        }
    }
}