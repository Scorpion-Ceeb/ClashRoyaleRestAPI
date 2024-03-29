﻿using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
