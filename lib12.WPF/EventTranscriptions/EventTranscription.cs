using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace lib12.WPF.EventTranscriptions
{
    /// <summary>
    /// Defines an Event transcription
    /// This inherits from freezable so that it gets inheritance context for DataBinding to work
    /// </summary>
    public class EventTranscription : Freezable, IDisposable
    {
        #region Fields
        private bool disposed = false;
        #endregion

        #region Props
        private DependencyObject owner;
        public DependencyObject Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                ResetEventBinding();
            }
        }

        public EventInfo Event { get; private set; }
        public Delegate EventHandler { get; private set; }
        #endregion

        #region Command
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(EventTranscription),
                new FrameworkPropertyMetadata(null));

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        #endregion

        #region CommandParameter
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventTranscription),
                new FrameworkPropertyMetadata(null));

        public object CommandParameter
        {
            get
            {
                return GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }
        #endregion

        #region EventName
        public static readonly DependencyProperty EventNameProperty = DependencyProperty.Register("EventName", typeof(string), typeof(EventTranscription),
                new FrameworkPropertyMetadata((string)null, new PropertyChangedCallback(EventName_Changed)));

        public string EventName
        {
            get
            {
                return (string)GetValue(EventNameProperty);
            }
            set
            {
                SetValue(EventNameProperty, value);
            }
        }

        private static void EventName_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((EventTranscription)d).OnEventNameChanged(e);
        }

        protected virtual void OnEventNameChanged(DependencyPropertyChangedEventArgs e)
        {
            ResetEventBinding();
        }
        #endregion

        #region Logic
        protected override Freezable CreateInstanceCore()
        {
            return this;
        }

        private void ResetEventBinding()
        {
            if (Owner != null)
            {
                if (Event != null && Owner != null)
                    Dispose();

                BindEvent();
            }
        }

        public void BindEvent()
        {
            Event = Owner.GetType().GetEvent(EventName, BindingFlags.Public | BindingFlags.Instance);
            if (Event == null)
                throw new InvalidOperationException(String.Format("Could not resolve event name {0}", EventName));

            EventHandler = EventHandlerTranscriber.Transcribe(Event.EventHandlerType, new EventHandler(Execute));
            Event.AddEventHandler(Owner, EventHandler);
        }

        public void Execute(object sender, EventArgs e)
        {
            var parameterType = typeof(EventTranscriptionParameter<>);
            var activationContext = parameterType.MakeGenericType(new Type[] { e.GetType() });
            var parameter = Activator.CreateInstance(activationContext);

            var props = activationContext.GetProperties();
            props[0].SetValue(parameter, sender, null);
            props[1].SetValue(parameter, e, null);
            props[2].SetValue(parameter, CommandParameter, null);

            if (Command.CanExecute(parameter))
                Command.Execute(parameter);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            if (!disposed)
            {
                Event.RemoveEventHandler(Owner, EventHandler);
                disposed = true;
            }
        }
        #endregion
    }
}
