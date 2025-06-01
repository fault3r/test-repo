using System;
using BookApi_Application.DTOs;
using MediatR;

namespace BookApi_Application.Commands
{
    public record AddBookCommand(string Title, string Author, int Year) : IRequest<BookDto>;
   
}