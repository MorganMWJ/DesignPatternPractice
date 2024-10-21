using Microsoft.VisualBasic;

namespace DesignPatternPractice.Builder;

internal class TodoBuilder
{
    private Todo todo;

    public TodoBuilder()
    {
        todo = new Todo();
    }

    internal TodoBuilder WithTitle(string title)
    {
        todo.Title = title;
        return this;
    }

    internal TodoBuilder WithDescription(string description)
    {
        todo.Description = description;
        return this;
    }

    internal TodoBuilder WithDueDate(DateTime dueDate)
    {
        todo.DueDate = dueDate;
        return this;
    }

    internal TodoBuilder WithPriority(int priority)
    {
        todo.Priority = priority;
        return this;
    }

    internal Todo Build()
    {
        return todo;
    }

    internal class Todo 
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Priority { get; set; }
    }
}
