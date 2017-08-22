using System;
using System.Collections.Specialized;
using System.Windows;

namespace lib12.WPF.EventTranscriptions
{
    /// <summary>
    /// Transcribes events into commands. Based on http://marlongrech.wordpress.com/2008/12/13/attachedcommandbehavior-v2-aka-acb/
    /// </summary>
    public class EventTranscriptions
    {
        private static readonly DependencyPropertyKey TranscriptionsPropertyKey = DependencyProperty.RegisterAttachedReadOnly("TranscriptionsInternal", typeof(EventTranscriptionsCollection), typeof(EventTranscriptions),
            new FrameworkPropertyMetadata((EventTranscriptionsCollection)null));

        public static readonly DependencyProperty TranscriptionsProperty = TranscriptionsPropertyKey.DependencyProperty;

        public static EventTranscriptionsCollection GetTranscriptions(DependencyObject dpObject)
        {
            if (dpObject == null)
                throw new InvalidOperationException("The dependency object trying to attach to is set to null");

            var collection = dpObject.GetValue(EventTranscriptions.TranscriptionsProperty) as EventTranscriptionsCollection;
            if (collection == null)
            {
                collection = new EventTranscriptionsCollection();
                collection.Owner = dpObject;
                SetTranscriptions(dpObject, collection);
            }
            return collection;
        }

        private static void SetTranscriptions(DependencyObject dpObject, EventTranscriptionsCollection value)
        {
            dpObject.SetValue(TranscriptionsPropertyKey, value);
            var collection = (INotifyCollectionChanged)value;
            collection.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
        }

        private static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var sourceCollection = (EventTranscriptionsCollection)sender;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                        foreach (EventTranscription item in e.NewItems)
                            item.Owner = sourceCollection.Owner;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                        foreach (EventTranscription item in e.OldItems)
                            item.Dispose();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.NewItems != null)
                        foreach (EventTranscription item in e.NewItems)
                            item.Owner = sourceCollection.Owner;

                    if (e.OldItems != null)
                        foreach (EventTranscription item in e.OldItems)
                            item.Dispose();
                    break;
                case NotifyCollectionChangedAction.Reset:
                    if (e.OldItems != null)
                        foreach (EventTranscription item in e.OldItems)
                            item.Dispose();
                    break;
                case NotifyCollectionChangedAction.Move:
                default:
                    break;
            }
        }
    }
}