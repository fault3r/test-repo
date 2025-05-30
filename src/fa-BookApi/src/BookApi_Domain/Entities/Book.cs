using System;

namespace BookApi_Domain.Entities
{
    public class Book
    {
        public required string Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public int Year { get; set; }
    }
}