
namespace ToDoTask;

public class ToDoNodeResolver
{
    public Task<ToDo> ResolveAsync(
        [Service] IMongoCollection<ToDo> collections,
        Guid id)
        {
            return collections.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
}