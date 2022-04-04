namespace ToDoTask;

public record UpdateToDoInput(
    Guid id,
    string Name,
    string Description);