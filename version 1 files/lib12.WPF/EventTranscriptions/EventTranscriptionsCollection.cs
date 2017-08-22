using System.Windows;

namespace lib12.WPF.EventTranscriptions
{
    /// <summary>
    /// Collection to store the list of event transcriptions, inherits from freezable so that it gets inheritance context for DataBinding to work
    /// </summary>
    public class EventTranscriptionsCollection : FreezableCollection<EventTranscription>
    {
        /// <summary>
        /// Gets or sets the Owner of the binding
        /// </summary>
        public DependencyObject Owner { get; set; }
    }
}