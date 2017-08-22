using System.Collections.Specialized;
using System.Windows;

namespace lib12.WPF.PushBinding
{
    //PushBinding from http://meleak.wordpress.com/2011/08/28/onewaytosource-binding-for-readonly-dependency-property/
    public class PushBindingCollection : FreezableCollection<PushBinding>
    {
        public PushBindingCollection()
        {
        }

        public PushBindingCollection(DependencyObject targetObject)
        {
            TargetObject = targetObject;
            ((INotifyCollectionChanged)this).CollectionChanged += CollectionChanged;
        }

        void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (PushBinding pushBinding in e.NewItems)
                {
                    pushBinding.SetupTargetBinding(TargetObject);
                }
            }
        }

        public DependencyObject TargetObject { get; private set; }
    }
}
