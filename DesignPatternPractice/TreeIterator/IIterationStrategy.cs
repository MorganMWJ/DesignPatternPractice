namespace DesignPatternPractice.TreeIterator;

public interface IIterationStrategy<TValue>
{
    IEnumerator<TreeNode<TValue>> GetIterator(TreeNode<TValue> tree);
}
