using System.Collections.Generic;
using lib12.WPF.Core;

namespace lib12.WPF.Test.Views
{
    class PushBindingViewModel : NotifyingObject
    {
        #region Props
        private bool isMouseOver;
        public bool IsMouseOver
        {
            get { return isMouseOver; }
            set
            {
                isMouseOver = value;
                OnPropertyChanged("IsMouseOver");
            }
        }

        private object[] selectedItems;
        public object[] SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                OnPropertyChanged("SelectedItems");
            }
        }

        public List<Item> Items { get; set; } 
        #endregion

        #region ctor
        public PushBindingViewModel()
        {
            Items = Item.GenerateItems();
        } 
        #endregion
    }
}
