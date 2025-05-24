using System;
using fa_mongodb.Models;
using MongoDB.Driver;

namespace fa_mongodb.Data
{
    public class MongoDbContext
    {
        public readonly IMongoDatabase _mongoDatabase;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(databaseName);
        }
        
        public IMongoCollection<Book> Books => _mongoDatabase.GetCollection<Book>("BooksCollection");
    }
}