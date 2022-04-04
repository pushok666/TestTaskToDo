using HotChocolate;
using MongoDB.Driver;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace ToDoTask;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IExecutable<ToDo> GetToDos([Service] IMongoCollection<ToDo> collection)
    {
        return collection.AsExecutable();
    }
        
    
    [UseFirstOrDefault]
    public IExecutable<ToDo> GetToDoById(
        [Service] IMongoCollection<ToDo> collection,
        [ID] Guid id)
        => collection.Find(x => x.Id == id).AsExecutable();   

    
}