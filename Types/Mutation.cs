namespace ToDoTask;

public class Mutation
{
    public async Task<CreateToDoPayload> CreateToDoAsync(
        [Service] IMongoCollection<ToDo> collection,
        CreateToDoInput input)
        {
            var toDo = new ToDo()
            {
                Name = input.Name,
                Description = input.Description
            };
            await collection.InsertOneAsync(toDo);

            return new CreateToDoPayload(toDo);
        }
    
    public async Task<string> DeleteToDoAsync(
        [Service] IMongoCollection<ToDo> collection,
        DeleteToDoInput input)
        {
            var deleteToDo = await collection.Find(x => x.Id == input.id).FirstOrDefaultAsync();
            
            if(deleteToDo == null)
                return "invalid operation";
            await collection.DeleteOneAsync(c => c.Id == deleteToDo.Id);
            return "Done";
        }
    
}