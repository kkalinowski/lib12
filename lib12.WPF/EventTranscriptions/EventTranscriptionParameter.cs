using System;

namespace lib12.WPF.EventTranscriptions
{
    public class EventTranscriptionParameter<TEventArgs> where TEventArgs : EventArgs
    {
        public object Sender { get; internal set; }
        public TEventArgs EventArgs { get; internal set; }
        public object CommandParameter { get; internal set; }
    }
}
