﻿using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
