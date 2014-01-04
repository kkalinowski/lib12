using System;
using System.ComponentModel;

namespace lib12.WPF.Core
{
    [Serializable]
    public class NotifyingObject : INotifyPropertyChanged
    {
        //cannot be serialized! - cos of propertyChangedEventManager, which isn't marked as serializable
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise PropertyChanged event for specified property
        /// </summary>
        /// <param name="propertyName">Property to notify change</param>
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
