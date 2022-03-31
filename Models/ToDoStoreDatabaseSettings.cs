namespace TestTaskToDo.Models;

public class ToDoStoreDatabaseSettings
{
    public string ConnectionString {get; set;} = null!;
    public string DatabaseName {get; set;} = null!;
    public string ToDoCollectionName {get; set;} = null!;
}