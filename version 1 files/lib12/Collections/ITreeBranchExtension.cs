namespace lib12.Collections
{
    public static class ITreeBranchExtension
    {
        public static bool IsLeaf<TId>(this ITreeBranch<TId> branch) where TId : struct
        {
            return branch.Children.IsNullOrEmpty();
        }

        public static bool IsRoot<TId>(this ITreeBranch<TId> branch) where TId : struct
        {
            return !branch.ParentId.HasValue;
        }
    }
}