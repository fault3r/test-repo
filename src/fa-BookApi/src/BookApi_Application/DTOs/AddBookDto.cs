using System;

namespace BookApi_Application.DTOs
{
    public class AddBookDto
    {
        public required string Title { get; set; }

        public required string Author { get; set; }

        public required int Year { get; set; }        
    }
}