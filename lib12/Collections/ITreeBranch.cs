using System.Collections;
using System.Collections.Generic;

namespace lib12.Collections
{
    public interface ITreeBranch<TId> where TId : struct
    {
        TId Id { get; }
        TId? ParentId { get; }
        IList<ITreeBranch<TId>> Children { get; }
        int Level { get; set; }
        bool IsRoot { get; set; }
        bool IsLeaf { get; set; }
    }
}