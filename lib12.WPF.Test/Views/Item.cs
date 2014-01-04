using System.Collections.Generic;
using lib12.Data.Dummy;

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
            var generator = new RandomClassGenerator();
            return generator.Generate<Item>(count,
                new StringPropertyGenerator<Item>(x => x.Text, 4, 9),
                new EnumPropertyGenerator<Item, SampleEnum>(x => x.EnumProp));
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
