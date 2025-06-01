using System;
using BookApi_Application.DTOs;
using MediatR;

namespace BookApi_Application.Queries
{
    public record GetBooksQuery : IRequest<IEnumerable<BookDto>>;
}