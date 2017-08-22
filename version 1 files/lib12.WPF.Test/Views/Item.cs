using System.Collections.Generic;
using System.Linq;
using lib12.Data.Random;

namespace lib12.WPF.Test.Views
{
    class Item
    {
        #region Props
        public string Text { get; set; }
        public SampleEnum EnumProp { get; set; }
        #endregion

        public static List<Item> GenerateItems(int count = 100)
        {
            return Rand.NextArrayOf<Item>(count).ToList();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
