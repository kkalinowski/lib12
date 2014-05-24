using lib12.Collections;
using System.Collections.Generic;

namespace lib12.Test.CollectionsTests
{
    public class Branch : ITreeBranch<int>
    {
        public int Id { get; private set; }
        public int? ParentId { get; private set; }
        public IList<ITreeBranch<int>> Children { get; private set; }
        public int Level { get; set; }
        public bool IsRoot { get; set; }
        public bool IsLeaf { get; set; }

        public Branch(int id, int? parentId = null)
        {
            Id = id;
            ParentId = parentId;
            Children = new List<ITreeBranch<int>>();
        }
    }
}