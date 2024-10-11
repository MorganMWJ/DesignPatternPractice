using System.Collections;

namespace DesignPatternPractice.TreeIterator;

public class TreeNode<TValue> : IEnumerable<TreeNode<TValue>>
{
    public TValue Value { get; set; }
    public TreeNode<TValue>? Parent { get; set; }
    public List<TreeNode<TValue>> Children { get; set; } = new List<TreeNode<TValue>>();
    public SearchType Search { get; set; } = SearchType.DepthFirst;

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
        if(Search == SearchType.DepthFirst)
        {
            return GetEnumeratorDepthFirst();
        }
        else
        {
            return GetEnumeratorBreadthFirst();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerator<TreeNode<TValue>> GetEnumeratorDepthFirst()
    {
        yield return this; // Yield the current node

        // Recursively iterate over each child in depth-first order
        foreach (var child in Children)
        {
            foreach (var descendant in child)
            {
                yield return descendant;
            }
        }
    }

    private IEnumerator<TreeNode<TValue>> GetEnumeratorBreadthFirst()
    {
        Queue<TreeNode<TValue>> queue = new Queue<TreeNode<TValue>>();
        queue.Enqueue(this); // Start with the root node

        while (queue.Count > 0)
        {
            TreeNode<TValue> current = queue.Dequeue();
            yield return current; // Process the current node

            // Enqueue all children of the current node
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
}

public enum SearchType
{
    DepthFirst,
    BreadthFirst
}