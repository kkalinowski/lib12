using System;
using System.Collections.Generic;

namespace lib12.Serialization
{
    public class SerializationStartedEventArgs : EventArgs
    {
        public Dictionary<string, object> Data { get; private set; }

        public SerializationStartedEventArgs()
        {
            Data = new Dictionary<string, object>();
        }
    }
}
