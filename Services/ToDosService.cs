using TestTaskToDo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TestTaskToDo.Services;

public class ToDosService
{

    private readonly IMongoCollection<ToDo> _todoCollection;
    public ToDosService(
        IOptions<ToDoStoreDatabaseSettings> todoStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                todoStoreDatabaseSettings.Value.ConnectionString);
            
            var mongoDatabase = mongoClient.GetDatabase(
                todoStoreDatabaseSettings.Value.DatabaseName);

            _todoCollection = mongoDatabase.GetCollection<ToDo>(
                todoStoreDatabaseSettings.Value.ToDoCollectionName);
        }
        public async Task<List<ToDo>> GetAsync() =>
            await _todoCollection.Find(_ => true).ToListAsync();
        public async Task<ToDo> GetAsync(string id) =>
            await _todoCollection.Find(f => f.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync( ToDo newToDo) =>
            await _todoCollection.InsertOneAsync(newToDo);
        public async Task UpdateAsync(string id, ToDo updateToDo) =>
            await _todoCollection.ReplaceOneAsync(r => r.Id ==id, updateToDo);
        public async Task RemoveAsync(string id) =>
            await _todoCollection.DeleteOneAsync(d => d.Id == id); 
}
