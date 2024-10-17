using System.Collections;

namespace DesignPatternPractice.TreeIterator;

public class TreeNode<TValue> : IEnumerable<TreeNode<TValue>>
{
    public TValue Value { get; set; }
    public TreeNode<TValue>? Parent { get; set; }
    public List<TreeNode<TValue>> Children { get; set; } = new List<TreeNode<TValue>>();
    public IIterationStrategy<TValue> IterationStrategy { get; set; } = new DepthFirstStrategy<TValue>();

    public TreeNode(TValue value)
    {
        Value = value;
        Parent = null;
    }

    public TreeNode(TValue value, TreeNode<TValue> parent)
    {
        Value = value;
        Parent = parent;
    }

    public bool IsLeaf => Children.Count == 0;

    public bool IsRoot => Parent == null;

    public void AddChild(TValue value)
    {
        var child = new TreeNode<TValue>(value, this);
        Children.Add(child);
    }
    public void AddChild(TreeNode<TValue> child)
    {
        Parent = this;
        Children.Add(child);
    }

    public IEnumerator<TreeNode<TValue>> GetEnumerator()
    {
        return IterationStrategy.GetIterator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}