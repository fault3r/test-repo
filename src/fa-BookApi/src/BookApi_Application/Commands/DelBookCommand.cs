using System;
using MediatR;

namespace BookApi_Application.Commands
{
    public record DelBookCommand(string Id) : IRequest<string>;
  
}