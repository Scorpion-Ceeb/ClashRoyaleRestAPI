﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

internal class AddBattleCommandHandler : ICommandHandler<AddBattleCommand, Guid>
{
    private readonly IBattleRepository _repository;

    public AddBattleCommandHandler(IBattleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(AddBattleCommand request, CancellationToken cancellationToken = default)
    {
        Guid id = await _repository.Add(request.WinnerId,
                                        request.LoserId,
                                        request.AmountTrophies,
                                        request.DurationInSeconds,
                                        request.Date);

        return id;

    }
}
