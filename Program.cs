using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using ToDoTask;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton(sp => 
    {
        const string connectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false";
        var mongoConnectionUrl = new MongoUrl(connectionString);
        var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
        mongoClientSettings.ClusterConfigurator = cb => 
        {
            cb.Subscribe<CommandStartedEvent>( e => 
            {
                Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
            });
        };
         var client = new MongoClient(mongoConnectionUrl);
        var database = client.GetDatabase("ToDoStore");
        return database.GetCollection<ToDo>("ToDo");
    })
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddGlobalObjectIdentification()
    .AddMongoDbFiltering()
    .AddMongoDbSorting()
    .AddMongoDbProjections()
    .AddMongoDbPagingProviders();

var app = builder.Build();

app.MapGraphQL();

app.Run();
