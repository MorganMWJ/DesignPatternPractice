namespace DesignPatternPractice.Composite_ObjectTree;

/// <summary>
/// The composite (or Object Tree) design pattern. 
/// This class represents a tree node.
/// Each node holds a reference to its children nodes in the tree.
/// Leaf nodes are those without children.
/// </summary>
internal class Node : INode
{
    public IList<INode> Children { get; set; } = new List<INode>();   

    public bool IsLeafNode => Children.Count == 0;

    public Node(INode child)
    {
        Children = [child]; // collection expression 
    }

    public Node(INode[] children)
    {
        Children = children;
    }

    void Add(INode node)
    {
        Children.Add(node);
    }

    void Remove(INode node)
    {
        if (IsLeafNode)
        {
            return;
        }

        var success = Children.Remove(node);
        if (!success)
        {
            throw new ArgumentException("Node param not one of this nodes children");
        }
    }

    public void Execute()
    {
        Console.WriteLine($"Tree node with {Children.Count} children");
    }
}
