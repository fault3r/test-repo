
using System;
using fa_mongodb.Data;
using fa_mongodb.Models;
using MongoDB.Driver;

namespace fa_mongodb.Repositories
{
    public class BookRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public BookRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;

        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _mongoDbContext.Books.Find<Book>(p => p.Id == id).FirstOrDefaultAsync();
            return book;
        }

        public async Task<bool> InsertBook(Book book)
        {
            await _mongoDbContext.Books.InsertOneAsync(book);
            return true;
        }
    }
}