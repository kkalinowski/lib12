using System.Collections.Generic;
using lib12.Collections;
using Should;
using Xunit;

namespace lib12.Test.Collections
{
    public class TreeTests
    {
        private List<ITreeBranch<int>> MakeThreeLevelList()
        {
            var list = new List<ITreeBranch<int>>();
            list.Add(new Branch(0));//0
            list.Add(new Branch(1));//1
            list.Add(new Branch(2));//2
            list.Add(new Branch(3, 0));//3
            list.Add(new Branch(4, 0));//4
            list.Add(new Branch(5, 0));//5
            list.Add(new Branch(6, 1));//6
            list.Add(new Branch(7, 1));//7
            list.Add(new Branch(8, 4));//8
            list.Add(new Branch(9, 4));//9

            return list;
        }

        public void organize_empty_list_into_hierarchy_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            var list = new List<ITreeBranch<int>>();

            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            Assert.NotNull(hierarchy);
            Assert.Empty(hierarchy);
        }

        [Fact]
        public void organize_list_into_flat_hierarchy_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            var list = new List<ITreeBranch<int>>
                {
                    new Branch(0),
                    new Branch(1),
                    new Branch(2)
                };


            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            Assert.NotNull(hierarchy);
            Assert.True(hierarchy.Count == 3);
        }

        [Fact]
        public void organize_list_into_one_level_hierarchy_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            var list = new List<ITreeBranch<int>>
                {
                    new Branch(0),
                    new Branch(1),
                    new Branch(2)
                };
            list.Add(new Branch(3,0));
            list.Add(new Branch(4,0));
            list.Add(new Branch(5,0));
            list.Add(new Branch(6,1));
            list.Add(new Branch(7,1));

            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            Assert.NotNull(hierarchy);
            Assert.True(hierarchy.Count == 3);
            Assert.True(hierarchy[0].Children.Count == 3);
            Assert.True(hierarchy[1].Children.Count == 2);
        }

        [Fact]
        public void organize_list_into_one_two_level_hierarchy_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            var list = this.MakeThreeLevelList();

            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            Assert.NotNull(hierarchy);
            Assert.True(hierarchy.Count == 3);
            Assert.True(hierarchy[0].Children.Count == 3);
            Assert.True(hierarchy[1].Children.Count == 2);
            Assert.True(hierarchy[0].Children[1].Children.Count == 2);
        }

        [Fact]
        public void hierarchy_level_computation_test()
        {
            var list = this.MakeThreeLevelList();

            Assert.DoesNotThrow(() => TreeHelper.BuildTree(list));
            Assert.Equal(1, list[0].Level);
            Assert.Equal(1, list[1].Level);
            Assert.Equal(1, list[2].Level);
            Assert.Equal(2, list[3].Level);
            Assert.Equal(2, list[4].Level);
            Assert.Equal(2, list[5].Level);
            Assert.Equal(2, list[6].Level);
            Assert.Equal(2, list[7].Level);
            Assert.Equal(3, list[8].Level);
            Assert.Equal(3, list[9].Level);
        }

        [Fact]
        public void flatten_hierarchy_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            List<ITreeBranch<int>> flattenHierarchy = null;
            var list = this.MakeThreeLevelList();

            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            Assert.DoesNotThrow(() => { flattenHierarchy = TreeHelper.FlattenHierarchy(hierarchy); });
            Assert.Same(list[0], flattenHierarchy[0]);
            Assert.Same(list[3], flattenHierarchy[1]);
            Assert.Same(list[4], flattenHierarchy[2]);
            Assert.Same(list[8], flattenHierarchy[3]);
            Assert.Same(list[9], flattenHierarchy[4]);
            Assert.Same(list[5], flattenHierarchy[5]);
            Assert.Same(list[1], flattenHierarchy[6]);
            Assert.Same(list[6], flattenHierarchy[7]);
            Assert.Same(list[7], flattenHierarchy[8]);
        }

        [Fact]
        public void jagged_hierarchy_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            var list = new List<ITreeBranch<int>>();
            list.Add(new Branch(0));//0
            list.Add(new Branch(1, 0));//1
            list.Add(new Branch(2));//2
            list.Add(new Branch(3));//3
            list.Add(new Branch(4, 3));//4
            list.Add(new Branch(5, 4));//5


            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            hierarchy.Count.ShouldEqual(3);
            list[0].Children.Count.ShouldEqual(1);
            list[1].Children.ShouldBeEmpty();
            list[2].Children.ShouldBeEmpty();
            list[3].Children.Count.ShouldEqual(1);
            list[4].Children.Count.ShouldEqual(1);
            list[5].Children.ShouldBeEmpty();
        }

        [Fact]
        public void jagged_hierarchy_without_given_roots_test()
        {
            List<ITreeBranch<int>> hierarchy = null;
            var list = new List<ITreeBranch<int>>();
            list.Add(new Branch(0));//0
            list.Add(new Branch(1));//1

            Assert.DoesNotThrow(() => { hierarchy = TreeHelper.BuildTree(list); });
            hierarchy.Count.ShouldEqual(2);
            list[0].Children.ShouldBeEmpty();
            list[1].Children.ShouldBeEmpty();
        }

        [Fact]
        public void is_root_test()
        {
            var tree = TreeHelper.BuildTree(MakeThreeLevelList());
            tree[0].IsRoot().ShouldBeTrue();
            tree[0].Children[0].IsRoot().ShouldBeFalse();
        }

        [Fact]
        public void is_leaf_test()
        {
            var tree = TreeHelper.BuildTree(MakeThreeLevelList());
            tree[0].IsLeaf().ShouldBeFalse();
            tree[0].Children[0].IsLeaf().ShouldBeTrue();
        }
    }
}