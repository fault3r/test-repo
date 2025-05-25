using System;
using fa_mongo.Data;
using fa_mongo.Entities;
using MongoDB.Driver;

namespace fa_mongo.Services
{
    public class BookService
    {
        private readonly MongoDbContext _mongoDbContext;

        public BookService(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<Book> GetBook(string title)
        {
            var filter = Builders<Book>.Filter.Eq(p => p.Title, title);
            var book = await _mongoDbContext.Books.Find(filter).FirstOrDefaultAsync();
            return book;
        }

        public async Task<string> AddBook(Book book)
        {
            await _mongoDbContext.Books.InsertOneAsync(book);
            return "the book added.";
        }

        public async Task<string> DelBook(string title)
        {
            var filter = Builders<Book>.Filter.Eq(p => p.Title, title);
            await _mongoDbContext.Books.DeleteOneAsync(filter);
            return $"the book '{title}' deleted!";
        }
    }
}