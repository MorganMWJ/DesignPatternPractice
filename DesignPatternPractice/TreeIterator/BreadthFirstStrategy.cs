
namespace DesignPatternPractice.TreeIterator;

public class BreadthFirstStrategy<T> : IIterationStrategy<T>
{
    public IEnumerator<TreeNode<T>> GetIterator(TreeNode<T> tree)
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(tree); // Start with the root node

        while (queue.Count > 0)
        {
            TreeNode<T> current = queue.Dequeue();
            yield return current; // Process the current node

            // Enqueue all children of the current node
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
}
