using System;
using fa_mongo.Data;
using fa_mongo.Entities;

namespace fa_mongo.Services
{
    public class BookService
    {
        private readonly MongoDbContext _mongoDbContext;

        public BookService(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task AddABook()
        {
            var book = new Book
            {
                Title = "test1",
                Author = "test2",
            };

            await _mongoDbContext.BooksCollection.InsertOneAsync(book);
        }
    }
}