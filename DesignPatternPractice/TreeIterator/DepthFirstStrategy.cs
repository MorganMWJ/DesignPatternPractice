
namespace DesignPatternPractice.TreeIterator;

public class DepthFirstStrategy<T> : IIterationStrategy<T>
{
    public IEnumerator<TreeNode<T>> GetIterator(TreeNode<T> tree)
    {
        yield return tree; // Yield the current node

        // Recursively iterate over each child in depth-first order
        foreach (var child in tree.Children)
        {
            foreach (var descendant in child)
            {
                yield return descendant;
            }
        }
    }
}
