﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;

internal class AddBattleCommandHandler : ICommandHandler<AddBattleCommand, Guid>
{
    private readonly IBattleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddBattleCommandHandler(IBattleRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AddBattleCommand request, CancellationToken cancellationToken = default)
    {
        Guid id = await _repository.Add(request.WinnerId,
                                        request.LoserId,
                                        request.AmountTrophies,
                                        request.DurationInSeconds,
                                        request.Date);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return id;

    }
}
