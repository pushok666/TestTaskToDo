using HotChocolate.Types.Relay;

namespace ToDoTask;

[Node(
    IdField = nameof(Id),
    NodeResolverType = typeof(ToDoNodeResolver),
    NodeResolver = nameof(ToDoNodeResolver.ResolveAsync))]
public class ToDo
{
    public Guid Id { get; init; }
    public string Name { get; init; } 
    public string Description { get; init; } 
}