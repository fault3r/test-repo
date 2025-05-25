using System;
using fa_mongo.Entities;
using MongoDB.Driver;

namespace fa_mongo.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _mongoDatabase;

    public MongoDbContext(string connectionString)
    {
        var mongoUrl = MongoUrl.Create(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        _mongoDatabase = mongoClient.GetDatabase("fa-mongodb");

    }

    public IMongoCollection<Book> Books => _mongoDatabase.GetCollection<Book>("BookCollection");
}
