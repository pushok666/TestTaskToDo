using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestTaskToDo.Models;

public class ToDo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id  {get; set;}
    [BsonElement("Name")]
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
}