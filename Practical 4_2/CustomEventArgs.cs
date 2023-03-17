using System;

namespace Practical_4_2
{
    internal class CustomEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public object Data { get; set; }
    }
}
