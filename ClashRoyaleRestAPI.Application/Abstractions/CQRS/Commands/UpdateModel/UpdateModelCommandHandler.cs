﻿using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Primitives;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.UpdateModel;

public class UpdateModelCommandHandler<TModel, UId> : ICommandHandler<UpdateModelCommand<TModel, UId>>
    where TModel : class, IEntity<UId>
{
    private readonly IBaseRepository<TModel, UId> _repository;
    public UpdateModelCommandHandler(IBaseRepository<TModel, UId> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateModelCommand<TModel, UId> request, CancellationToken cancellationToken = default)
    {
        await _repository.Update(request.Model);

        return Result.Success();
    }
}
