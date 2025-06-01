using System;
using BookApi_Infrastructure.Configurations;
using BookApi_Infrastructure.Data.Contexts.Documents;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookApi_Infrastructure.Data.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbContext(IOptions<MongodbSettings> settings)
        {
            var url = MongoUrl.Create(settings.Value.ConnectionString);
            var client = new MongoClient(url);
            _mongoDatabase = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<BookDocument> Books =>
            _mongoDatabase.GetCollection<BookDocument>(nameof(Books));
    }
}