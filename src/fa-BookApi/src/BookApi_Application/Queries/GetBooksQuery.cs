using System;
using BookApi_Application.DTOs;
using MediatR;

namespace BookApi_Application.Queries
{
    public record GetBooksQuery(int p = 1) : IRequest<IEnumerable<BookDto>>;
}