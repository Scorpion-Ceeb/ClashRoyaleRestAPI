﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.DeleteWar;

internal class DeleteWarCommandHandler : DeleteModelCommandHandler<WarModel, WarId>
{
    public DeleteWarCommandHandler(IWarRepository repository) : base(repository)
    {
    }
}
