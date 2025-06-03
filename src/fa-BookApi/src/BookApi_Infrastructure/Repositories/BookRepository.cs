using System;
using System.Collections;
using BookApi_Domain.Entities;
using BookApi_Domain.Interfaces;
using BookApi_Infrastructure.Data.Contexts;
using BookApi_Infrastructure.Data.Contexts.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookApi_Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoDbContext _mongoDbContext;

        public BookRepository(MongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var filter = Builders<BookDocument>.Filter.Empty;
            var mBooks = await _mongoDbContext.Books.FindAsync(filter);
            return mBooks.ToEnumerable().Select(r => new Book
            {
                Id = r.Id.ToString(),
                Title = r.Title,
                Author = r.Author,
                Year = r.Year,
            });
        }

        public async Task<Book> GetBookAsync(string id)
        {
            var filter = Builders<BookDocument>.Filter.Eq(p => p.Id, new ObjectId(id));
            var mBook = await _mongoDbContext.Books.Find(filter).FirstOrDefaultAsync();
            return new Book
            {
                Id = mBook.Id.ToString(),
                Title = mBook.Title,
                Author = mBook.Author,
                Year = mBook.Year,
            };
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var mBook = new BookDocument
            {
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            };
            await _mongoDbContext.Books.InsertOneAsync(mBook);
            book.Id = mBook.Id.ToString();
            return book;
        }

        public async Task<string> DelBookAsync(string id)
        {
            var result = await _mongoDbContext.Books.DeleteOneAsync(p => p.Id.ToString() == id);
            return result.ToJson();
        }
    }
}