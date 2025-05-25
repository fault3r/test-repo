using System;
using fa_mongo.Entities;
using MongoDB.Driver;

namespace fa_mongo.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<Book> _bookCollection;

        public MongoDbContext()
        {
            string connectionString = "mongodb://127.0.0.1:27017";

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _mongoDatabase = mongoClient.GetDatabase("mongodbbooks");
            _bookCollection = _mongoDatabase.GetCollection<Book>("mongocolbooks");
        }

        public IMongoCollection<Book> BooksCollection => _bookCollection;    
    }
}