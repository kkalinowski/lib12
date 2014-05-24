using System.Collections.Generic;
using System.Linq;
using lib12.Extensions;

namespace lib12.Collections
{
    public static class TreeHelper
    {
        public static List<ITreeBranch<TId>> BuildTree<TId>(IEnumerable<ITreeBranch<TId>> items) where TId : struct
        {
            var roots = items.Where(x => x.ParentId.Null()).ToList();

            var dict = items.ToDictionary(x => x.Id, x => x);
            foreach (var item in dict.Where(x => x.Value.ParentId.HasValue))
            {
                var parent = dict.GetValueOrDefault(item.Value.ParentId.Value);
                parent.Children.Add(item.Value);
            }

            ComputeLevel(roots);
            return roots;
        }

        private static void ComputeLevel<TId>(IEnumerable<ITreeBranch<TId>> hierarchyItems, int parentLevel = 0) where TId : struct
        {
            foreach (var item in hierarchyItems)
            {
                item.Level = parentLevel + 1;
                ComputeLevel(item.Children, parentLevel + 1);
            }
        }

        public static List<ITreeBranch<TId>> FlattenHierarchy<TId>(IEnumerable<ITreeBranch<TId>> hierarchyItems) where TId : struct
        {
            var flattenHierarchy = new List<ITreeBranch<TId>>();

            foreach (var item in hierarchyItems)
            {
                flattenHierarchy.Add(item);
                FlattenHierarchy(item.Children, flattenHierarchy);
            }

            return flattenHierarchy;
        }

        private static void FlattenHierarchy<TId>(IEnumerable<ITreeBranch<TId>> hierarchyItems, List<ITreeBranch<TId>> flattenHierarchy) where TId : struct
        {
            foreach (var item in hierarchyItems)
            {
                flattenHierarchy.Add(item);
                FlattenHierarchy(item.Children, flattenHierarchy);
            }
        }
    }
}