using System;
using BookApi_Application.DTOs;
using MediatR;

namespace BookApi_Application.Queries
{
    public record GetBookQuery(string Id) : IRequest<BookDto>;
}