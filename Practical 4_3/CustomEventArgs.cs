using System;

namespace Practical_4_3
{
    public class CustomEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public object Data { get; set; }
    }
}
