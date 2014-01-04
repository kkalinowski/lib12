using System.Collections.Generic;
using lib12.WPF.Core;

namespace lib12.WPF.Test.Views
{
    class DataBasedTemplateSelectorViewModel : NotifyingObject
    {
        public List<Item> Items { get; set; }

        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public DataBasedTemplateSelectorViewModel()
        {
            Items = Item.GenerateItems(10);
        }
    }
}
